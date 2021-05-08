using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;

namespace ServerDataLayer
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _dataContext;
        private readonly object _deviceLock = new object();

        public DeviceRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region IDeviceRepository

        public void Add(IDevice item)
        {
            _dataContext.Devices.Add(item);
        }

        public IDevice Get(string name)
        {
            return _dataContext.Devices.Find(device => device.Name == name);
        }

        public async Task<IEnumerable<IDevice>> Get()
        {
            return await Task.FromResult(_dataContext.Devices);
        }

        public IDevice Get(int id)
        {
            return _dataContext.Devices.Find(device => device.Id == id);
        }

        public IEnumerable<IDevice> GetAll(string name)
        {
            return _dataContext.Devices.FindAll(device => device.Name == name);
        }

        public int[] GetIds(string name)
        {
            List<IDevice> found = _dataContext.Devices.FindAll(device => device.Name == name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return _dataContext.Devices.RemoveAll(device => device.Name == name);
        }

        public int Remove(int id)
        {
            return _dataContext.Devices.RemoveAll(device => device.Id == id);
        }

        public bool Remove(IDevice item)
        {
            return _dataContext.Devices.Remove(item);
        }

        public bool Update(int id, IDevice item)
        {
            IDevice found = _dataContext.Devices.Find(device => device.Id == id);
            bool returnValue = false;
            if (found != null)
            {
                lock(_deviceLock)
                {
                    found.Name = item.Name;
                    found.Enabled = item.Enabled;
                }
                returnValue = true;
            }
            return returnValue;
        }

        public int UpdateAll(string name, IDevice item)
        {
            List<IDevice> found = _dataContext.Devices.FindAll(device => device.Name == name);
            foreach (var d in found)
            {
                lock(_deviceLock)
                {
                    d.Enabled = item.Enabled;
                }
            }
            return found.Count;
        }

        public bool SetState(int id, bool enabled)
        {
            IDevice device = Get(id);
            bool returnValue = false;
            if (device != null)
            {
                lock(_deviceLock)
                {
                    device.Enabled = enabled;
                }
                returnValue = true;
            }

            return returnValue;
        }

        public int SetStates(string name, bool enabled)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                lock (_deviceLock)
                {
                    device.Enabled = enabled;
                }
            }
            return devices.Count;
        }

        public bool Toggle(int id)
        {
            IDevice device = Get(id);
            bool returnValue = false;
            if (device != null)
            {
                lock (_deviceLock)
                {
                    device.Enabled = !device.Enabled;
                }
                returnValue = true;
            }

            return returnValue;
        }

        public int ToggleAll(string name)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                lock (_deviceLock)
                {
                    device.Enabled = !device.Enabled;
                }
            }
            return devices.Count;
        } 
        #endregion
    }
}
