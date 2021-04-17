using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _dataContext;

        public DeviceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<IDevice> Get()
        {
            return _dataContext.Devices;
        }

        public IDevice Get(int id)
        {
            return _dataContext.Devices.Find(device => device.Id == id);
        }

        public void Add(IDevice item)
        {
            _dataContext.Devices.Add(item);
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
            if (found != null)
            {
                found.Name = item.Name;
                found.Enabled = item.Enabled;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IDevice Get(string name)
        {
            return _dataContext.Devices.Find(device => device.Name == name);
        }

        public IEnumerable<IDevice> GetAll(string name)
        {
            return _dataContext.Devices.FindAll(device => device.Name == name);
        }

        public int GetFirstId(string name)
        {
            IDevice found = _dataContext.Devices.Find(device => device.Name == name);
            if (found != null)
            {
                return found.Id;
            }
            else
            {
                return -1;
            }
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

        public bool UpdateFirst(string name, IDevice item)
        {
            IDevice found = _dataContext.Devices.Find(device => device.Name == name);
            if (found != null)
            {
                found.Enabled = item.Enabled;
                found.Name = item.Name;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UpdateAll(string name, IDevice item)
        {
            List<IDevice> found = _dataContext.Devices.FindAll(device => device.Name == name);
            foreach (var t in found)
            {
                t.Enabled = item.Enabled;
                t.Name = item.Name;
            }
            return found.Count;
        }

        public bool SetState(int id, bool enabled)
        {
            IDevice device = Get(id);
            if (device != null)
            {
                device.Enabled = enabled;
                return true;
            }

            return false;
        }

        public bool SetStateFirst(string name, bool enabled)
        {
            IDevice device = Get(name);
            if (device != null)
            {
                device.Enabled = enabled;
                return true;
            }

            return false;
        }

        public int SetStates(string name, bool enabled)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                device.Enabled = enabled;
            }
            return devices.Count;
        }

        public bool Toggle(int id)
        {
            IDevice device = Get(id);
            if (device != null)
            {
                device.Enabled = !device.Enabled;
                return true;
            }

            return false;
        }

        public bool ToggleFirst(string name)
        {
            IDevice device = Get(name);
            if (device != null)
            {
                device.Enabled = !device.Enabled;
                return true;
            }

            return false;
        }

        public int ToggleAll(string name)
        {
            List<IDevice> devices = (List<IDevice>)GetAll(name);
            foreach (var device in devices)
            {
                device.Enabled = !device.Enabled;
            }
            return devices.Count;
        }
    }
}
