using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class ExampleDevice : IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool LastState { get; set; }
    }
}
