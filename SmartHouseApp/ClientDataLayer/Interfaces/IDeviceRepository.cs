using System.Threading.Tasks;
using ModelCommon.Interfaces;

namespace ClientDataLayer.Interfaces
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public Task<bool> Toggle(int id);
    }
}
