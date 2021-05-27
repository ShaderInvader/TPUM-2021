using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using ClientDataLayer.Interfaces;

namespace ClientDataLayer
{
    public class DataContext
    {
        // Singleton implementation
        private static DataContext _instance;
        public static DataContext Instance
        {
            get { return _instance ??= new DataContext(); }
            private set => _instance = value;
        }

        public async Task RequestDataUpdate()
        {
            _isAwaitingResponse = true;

            await WebSocketClient.CurrentConnection.SendAsync("UpdateDataRequest");

            while (_isAwaitingResponse) {}
        }

        public async Task RequestWithConfirmation(string request)
        {
            _isAwaitingConfirmation = true;

            await WebSocketClient.CurrentConnection.SendAsync(request);

            while (_isAwaitingConfirmation) { }
        }

        public void ReceiveData(string data)
        {
            var split = data.Split('[');
            if (string.Compare(split[0], "Devices", StringComparison.Ordinal) == 0)
            {
                lock (devicesLock)
                {
                    Devices.Clear();

                    var toDeserialize = split[1].Insert(0, "[");
                    var deserialized = JsonSerializer.Deserialize<List<ExampleDevice>>(toDeserialize);
                    Devices = new List<IDevice>(deserialized!);
                    DevicesChanged?.Invoke();
                }

                _isAwaitingResponse = false;
            }
            else if (string.Compare(split[0], "Confirm", StringComparison.Ordinal) == 0)
            {
                _isAwaitingConfirmation = false;
            }
        }

        private bool _isAwaitingConfirmation = false;
        private bool _isAwaitingResponse = false;

        public event Action DevicesChanged;

        public List<User> Users { get; set; } = new List<User>();
        public object usersLock = new object();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public object roomsLock = new object();
        public List<IDevice> Devices { get; set; } = new List<IDevice>();
        public object devicesLock = new object();
    }
}
