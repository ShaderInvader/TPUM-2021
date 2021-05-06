using System;
using System.Collections.Generic;
using System.Text;
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

        public List<House> Houses { get; set; } = new List<House>();

        public List<User> Users { get; set; } = new List<User>();

        public List<IDevice> Devices { get; set; } = new List<IDevice>();
    }
}
