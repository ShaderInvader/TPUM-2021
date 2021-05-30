using System;
using System.Threading.Tasks;

namespace ClientDataLayer.Interfaces
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public Task<bool> Toggle(int id);
        public Task SubscribeDevice(IDevice device);
        public Task DisposeDevice(IDevice device);

        public event Action<IDevice> OnDeviceChanged;
    }
}
