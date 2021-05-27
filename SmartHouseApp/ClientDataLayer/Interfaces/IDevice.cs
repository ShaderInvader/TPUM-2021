namespace ClientDataLayer.Interfaces
{
    public interface IDevice : INamed
    {
        public bool Enabled { get; set; }
        public bool LastState { get; set; }
    }
}
