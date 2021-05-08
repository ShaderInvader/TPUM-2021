using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon;
using ModelCommon.Interfaces;

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

        public void ParseData(string data)
        {
            lock (devicesLock) lock (roomsLock) lock (usersLock)
            {
                Users.Clear();
                Rooms.Clear();
                Devices.Clear();


            }
        }

        public List<User> Users { get; set; } = new List<User>();
        public object usersLock = new object();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public object roomsLock = new object();
        public List<IDevice> Devices { get; set; } = new List<IDevice>();
        public object devicesLock = new object();
    }
}
