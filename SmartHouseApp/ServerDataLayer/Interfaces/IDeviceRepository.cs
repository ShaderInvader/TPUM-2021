using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public int SetStates(string name, bool enabled);
        public bool Toggle(int id);
        public int ToggleAllByName(string name);
        public bool TurnOffAll();
    }
}
