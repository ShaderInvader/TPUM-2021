using ServerLogicLayer;
using System;
using System.Threading.Tasks;

namespace ServerPresentationLayer
{
    class Program
    {
        private static WebSocketConnection CurrentConnection;
        private static readonly IDeviceService deviceService = new DeviceService();
        private static LocationTracker provider;
        private static LocationReporter reporter;


        static async Task Main(string[] args)
        {
            provider = new LocationTracker();
            var min = new Tuple<double, double>(-10, -10);
            var max = new Tuple<double, double>(10, 10);
            reporter = new LocationReporter(Mapper.Map(new LocationDTO { Coordinates = min }), Mapper.Map(new LocationDTO { Coordinates = max}));

            reporter.Subscribe(provider,
                Console.WriteLine, 
                (x) => Console.WriteLine(x.Message), 
                (x) => Console.WriteLine($"New Coordinates: {x.Coordinates.Item1}, {x.Coordinates.Item2}"),
                () => { Console.WriteLine("Turning off all devices"); Task.Run(() => deviceService.TurnOffAllDevices()); }
                );
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            CurrentConnection = webSocketConnection;
            webSocketConnection.onMessage = ParseMessage;
            webSocketConnection.onClose = () => { Console.WriteLine("Connection closed"); };
            webSocketConnection.onError = () => { Console.WriteLine("Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Console.WriteLine(message);
            if(message.Contains("UpdateDataRequest"))
            {
                await CurrentConnection.SendAsync(Serializer.AllDataToJson(deviceService));
            }
            else if(message.Contains("ToggleDevice"))
            {
                var splited = message.Split(':');
                int id = Serializer.IntFromJson(splited[1]);
                await deviceService.ToggleDevice(id);
                await CurrentConnection.SendAsync("Confirm");
            }
            else if(message.Contains("AddDevice"))
            {
                var json = message.Substring("AddDevice".Length - 1);
                ExampleDeviceDTO device = Serializer.DeviceFormJson(json);
                await deviceService.AddDevice(device);
                await CurrentConnection.SendAsync("Confirm");
            }
            else if(message.Contains("Location"))
            {
                var split = message.Split('(');
                split = split[1].Split(',');
                split[1] = split[1].Substring(1, split.Length - 1);
                double x = Double.Parse(split[0]);
                double y = Double.Parse(split[1]);
                provider.TrackLocation(Mapper.Map(new LocationDTO { Coordinates = new Tuple<double, double>(x, y) }));
            }
        }
    }
}
