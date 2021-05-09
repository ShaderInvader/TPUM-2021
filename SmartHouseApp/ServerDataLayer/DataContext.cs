using System.Collections.Generic;
using ModelCommon;
using ModelCommon.Interfaces;

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

        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<User> Users { get; set; } = new List<User>();

        public List<IDevice> Devices { get; set; } = new List<IDevice>();
    }
}
