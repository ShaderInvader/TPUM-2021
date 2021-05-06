using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public bool SetStateFirst(string name, bool enabled);
        public int SetStates(string name, bool enabled);
        public bool Toggle(int id);
        public bool ToggleFirst(string name);
        public int ToggleAll(string name);
    }
}
