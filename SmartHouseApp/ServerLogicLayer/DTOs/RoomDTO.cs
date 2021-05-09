using System.Collections.Generic;
using ModelCommon.Interfaces;

namespace ServerLogicLayer
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; }
    }
}
