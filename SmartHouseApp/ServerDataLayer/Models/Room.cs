using System.Collections.Generic;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class Room : INamed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IDevice> Devices { get; set; }
    }
}
