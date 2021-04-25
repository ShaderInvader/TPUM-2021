using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DeviceDTO> Devices { get; set; }
    }
}
