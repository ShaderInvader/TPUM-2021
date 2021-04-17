using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer.Devices
{
    class WallSocket : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
