using ServerLogicLayer;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ServerPresentationLayer
{
    public class Program
    {
        private static WebSocketConnection CurrentConnection;
        private static readonly IDeviceService deviceService = new DeviceService();
        private static LocationTracker locationProvider;
        private static LocationReporter locationReporter;
        private static DeviceTracker deviceProvider;
        private static DeviceReporter deviceReporter;
        private static ExampleDeviceDTO updatedDevice = null;

        static async Task Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            locationProvider = new LocationTracker();
            var min = new LocationDTO{Longitude = -10, Latitude = -10};
            var max = new LocationDTO { Longitude = 10, Latitude = 10 };
            locationReporter = new LocationReporter(Mapper.Map(min), Mapper.Map(max));

            locationReporter.Subscribe(locationProvider,
                Console.WriteLine, 
                (x) => Console.WriteLine(x.Message),
                (x) => { },
                TurnOffAll,
                TurnOnAll
                );
            deviceProvider = new DeviceTracker();
            deviceReporter = new DeviceReporter();
            deviceReporter.Subscribe(deviceProvider,
                Console.WriteLine,
                (x) => Console.WriteLine(x.Message),
                (x) => { _ = CurrentConnection.SendAsync(MessageParser.CreateMessage("OnNext", x, x.GetType().Name)); }
                );
            await CreateServer();
        }

        public static async Task CreateServer()
        {
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
                    if(updatedDevice == null)
                    {
                        updatedDevice = MessageParser.DeserializeType<ExampleDeviceDTO>(msg.Data.ToString());
                        _ = Task.Run(() => UpdateDeviceTimer());
                        _ = SendConfirm();
                    }
                    break;
                case "Dispose":
                    var device = MessageParser.DeserializeType<ExampleDeviceDTO>(msg.Data.ToString());
                    if(device.Id == updatedDevice.Id)
                    {
                        updatedDevice = null;
                        _ = SendConfirm();
                    }
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
                    locationProvider.TrackLocation(Mapper.Map(location));
                    break;
            }
        }

        static async Task UpdateDeviceTimer()
        {
            while(updatedDevice != null)
            {
                await deviceService.ToggleDevice(updatedDevice.Id);
                var newDevice = deviceService.GetDevice(updatedDevice.Id).Result;
                deviceProvider.TrackDevice(Mapper.Map(newDevice));
                System.Threading.Thread.Sleep(2000);
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
