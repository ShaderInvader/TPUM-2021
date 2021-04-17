using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Devices;
using DataLayer.Interfaces;

namespace DataLayer
{
    public class Room : INamed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IDevice> Devices { get; set; }
    }
}
