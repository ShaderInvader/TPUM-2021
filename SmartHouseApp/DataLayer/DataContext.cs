using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DataContext
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<House> Houses { get; set; } = new List<House>();
        public List<IDevice> Devices { get; set; } = new List<IDevice>();
    }
}
