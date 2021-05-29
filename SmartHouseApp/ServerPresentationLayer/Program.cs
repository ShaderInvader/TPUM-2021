using ServerLogicLayer;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ServerPresentationLayer
{
    class Program
    {
        private static WebSocketConnection CurrentConnection;
        private static readonly IDeviceService deviceService = new DeviceService();
        private static LocationTracker provider;
        private static LocationReporter reporter;


        static async Task Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            provider = new LocationTracker();
            var min = new Tuple<double, double>(-10, -10);
            var max = new Tuple<double, double>(10, 10);
            reporter = new LocationReporter(Mapper.Map(new LocationDTO { Coordinates = min }), Mapper.Map(new LocationDTO { Coordinates = max}));

            reporter.Subscribe(provider,
                Console.WriteLine, 
                (x) => Console.WriteLine(x.Message),
                (x) => { },
                TurnOffAll,
                TurnOnAll
                );
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            CurrentConnection = webSocketConnection;
            webSocketConnection.onMessage = ParseMessage;
            webSocketConnection.onClose = () => { Console.WriteLine("[Server]: Connection closed"); };
            webSocketConnection.onError = () => { Console.WriteLine("[Server]: Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Message msg = MessageParser.DeserializeMessage(message);
            Console.WriteLine($"[Client] Command: {msg.Command}");
            switch(msg.Command)
            {
                case "Subscribe":
                    break;
                case "UpdateAll":
                    var devices = deviceService.GetDevices().Result;
                    _ = CurrentConnection.SendAsync(MessageParser.CreateMessage("UpdateAll", devices, devices.GetType().Name));
                    break;
                case "Add":
                    var deviceToAdd = msg.Data as ExampleDeviceDTO;
                    await deviceService.AddDevice(deviceToAdd);
                    _ = SendConfirm();
                    break;
                case "Toggle":
                    var deviceId = msg.Data as int?;
                    if(deviceId != null)
                    {
                        await deviceService.ToggleDevice(deviceId.Value);
                        _ = SendConfirm();
                    }
                    break;
                case "OnNext":
                    var location = msg.Data as Tuple<double, double>;
                    provider.TrackLocation(Mapper.Map(new LocationDTO() { Coordinates = location }));
                    break;
            }
            
        }

        static async Task SendConfirm()
        {
            await CurrentConnection.SendAsync(MessageParser.CreateMessage("Confirm", "", "void"));
        }

        static async void TurnOffAll()
        {
            Console.WriteLine("[Server]: Turning off all devices"); 
            await deviceService.TurnOffAllDevices();
        }

        static async void TurnOnAll()
        {
            Console.WriteLine("[Server]: Client returns home - turn on last devices"); 
            await deviceService.TurnOnLastDevices();
        }

    }
}
