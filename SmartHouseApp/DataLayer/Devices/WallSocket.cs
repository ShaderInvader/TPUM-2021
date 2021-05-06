using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class WallSocket : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
