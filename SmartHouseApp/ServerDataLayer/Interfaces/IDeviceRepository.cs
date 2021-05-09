using ModelCommon.Interfaces;

namespace ServerDataLayer
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public bool Toggle(int id);
        public bool TurnOffAll();
        public bool ApplyLastStateOnAll();
    }
}
