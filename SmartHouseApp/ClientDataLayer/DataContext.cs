﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ModelCommon;
using ModelCommon.Interfaces;
using System.Text.Json;

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
            await WebSocketClient.CurrentConnection.SendAsync("UpdateDataRequest");

            var requestTimeout = Stopwatch.StartNew();
            _isAwaitingResponse = true;

            while (_isAwaitingResponse && requestTimeout.Elapsed.Seconds > Timeout) { ; }

            _isAwaitingResponse = false;
        }

        public void ReceiveData(string data)
        {
            var split = data.Split('[');
            if (string.Compare(split[0], "Devices", StringComparison.Ordinal) == 0)
            {
                lock (devicesLock) lock (roomsLock) lock (usersLock)
                {
                    Users.Clear();
                    Rooms.Clear();
                    Devices.Clear();


                    var toDeserialize = split[1].Insert(0, "[");
                    var deserialized = JsonSerializer.Deserialize<List<ExampleDevice>>(toDeserialize);
                    Devices = new List<IDevice>(deserialized!);
                }

                _isAwaitingResponse = false;
            }
        }

        private bool _isAwaitingResponse = false;
        private const int Timeout = 60;

        public List<User> Users { get; set; } = new List<User>();
        public object usersLock = new object();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public object roomsLock = new object();
        public List<IDevice> Devices { get; set; } = new List<IDevice>();
        public object devicesLock = new object();
    }
}
