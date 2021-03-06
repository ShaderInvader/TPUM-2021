using System.Collections.Generic;
using ServerDataLayer.Interfaces;

namespace ServerLogicLayer
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; }
    }
}
