using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string Type { get; set; }
    }
}
