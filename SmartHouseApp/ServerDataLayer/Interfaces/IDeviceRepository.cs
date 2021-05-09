using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface IDeviceRepository : INamedRepository<IDevice>
    {
        public bool SetState(int id, bool enabled);
        public bool Toggle(int id);
        public bool TurnOffAll();
        public bool ApplyLastStateOnAll();
    }
}
