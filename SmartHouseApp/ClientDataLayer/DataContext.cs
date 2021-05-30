using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

            await WebSocketClient.CurrentConnection.SendAsync(MessageParser.CreateMessage("UpdateAll", "", "void"));

            while (_isAwaitingResponse) {}
        }

        public async Task RequestWithConfirmation(string msg)
        {
            _isAwaitingConfirmation = true;

            await WebSocketClient.CurrentConnection.SendAsync(msg);

            while (_isAwaitingConfirmation) { }
        }

        public void ReceiveData(string data)
        {
            var msg = MessageParser.DeserializeMessage(data);
            Debug.WriteLine($"[Server] {msg.Command}");
            switch (msg.Command)
            {
                case "UpdateAll":
                    var objectList = MessageParser.DeserializeType<List<ExampleDevice>>(msg.Data.ToString());
                    lock (devicesLock)
                    {
                        Devices.Clear();
                        Devices = new List<IDevice>(objectList);
                    }
                    DevicesChanged?.Invoke();
                    _isAwaitingResponse = false;
                    break;
                case "OnNext":
                    var sendDevice = MessageParser.DeserializeType<ExampleDevice>(msg.Data.ToString());
                    var changedDevice = Devices.Find((x) => x.Id == sendDevice.Id);
                    lock (devicesLock)
                    {
                        changedDevice.LastState = sendDevice.LastState;
                        changedDevice.Enabled = sendDevice.Enabled;
                    }
                    OnDeviceChange?.Invoke(changedDevice);
                    break;
                case "Confirm":
                    _isAwaitingConfirmation = false;
                    break;
            }
        }

        private bool _isAwaitingConfirmation = false;
        private bool _isAwaitingResponse = false;

        public event Action DevicesChanged;
        public event Action<IDevice> OnDeviceChange;

        public List<User> Users { get; set; } = new List<User>();
        public object usersLock = new object();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public object roomsLock = new object();
        public List<IDevice> Devices { get; set; } = new List<IDevice>();
        public object devicesLock = new object();
    }
}
