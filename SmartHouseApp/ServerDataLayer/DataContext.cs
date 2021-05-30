using System.Collections.Generic;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class DataContext
    {
        public static DataContext Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataContext();
                }
                return _instance;
            }
        }
        private static DataContext _instance = null;

        public void ClearContext()
        {
            Rooms.Clear();
            Users.Clear();
            Devices.Clear();
        }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<User> Users { get; set; } = new List<User>();

        public List<IDevice> Devices { get; set; } = new List<IDevice>();
    }
}
