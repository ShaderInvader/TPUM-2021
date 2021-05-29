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
            var min = new LocationDTO{Longitude = -10, Latitude = -10};
            var max = new LocationDTO { Longitude = 10, Latitude = 10 };
            reporter = new LocationReporter(Mapper.Map(min), Mapper.Map(max));

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
                    _ = SendUpdateAll();
                    break;
                case "Add":
                    var deviceToAdd = MessageParser.DeserializeType<ExampleDeviceDTO>(msg.Data.ToString());
                    await deviceService.AddDevice(deviceToAdd);
                    _ = SendConfirm();
                    break;
                case "Toggle":
                    var deviceId = MessageParser.DeserializeType<int>(msg.Data.ToString());
                    await deviceService.ToggleDevice(deviceId);
                    _ = SendConfirm();
                    break;
                case "OnNext":
                    var location = MessageParser.DeserializeType<LocationDTO>(msg.Data.ToString());
                    provider.TrackLocation(Mapper.Map(location));
                    break;
            }
            
        }

        static async Task SendConfirm()
        {
            await CurrentConnection.SendAsync(MessageParser.CreateMessage("Confirm", "", "void"));
        }

        static async Task SendUpdateAll()
        {
            var devices = deviceService.GetDevices().Result;
            await CurrentConnection.SendAsync(MessageParser.CreateMessage("UpdateAll", devices, devices.GetType().Name));
        }

        static async void TurnOffAll()
        {
            Console.WriteLine("[Server]: Turning off all devices"); 
            await deviceService.TurnOffAllDevices();
            _ = SendUpdateAll();
        }

        static async void TurnOnAll()
        {
            Console.WriteLine("[Server]: Client returns home - turn on last devices"); 
            await deviceService.TurnOnLastDevices();
            _ = SendUpdateAll();
        }

    }
}
