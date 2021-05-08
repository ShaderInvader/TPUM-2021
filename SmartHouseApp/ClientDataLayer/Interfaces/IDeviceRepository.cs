using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;

namespace ClientDataLayer.Interfaces
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public int SetStates(string name, bool enabled);
        public Task<bool> Toggle(int id);
        public int ToggleAll(string name);
    }
}
