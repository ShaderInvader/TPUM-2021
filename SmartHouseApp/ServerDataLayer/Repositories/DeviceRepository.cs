﻿using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;

namespace ServerDataLayer
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _dataContext;

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

        public IEnumerable<IDevice> Get()
        {
            return _dataContext.Devices;
        }

        public IDevice Get(int id)
        {
            return _dataContext.Devices.Find(device => device.Id == id);
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
                found.Name = item.Name;
                found.Enabled = item.Enabled;
                returnValue = true;
            }
            return returnValue;
        }

        public bool UpdateFirst(string name, IDevice item)
        {
            IDevice found = _dataContext.Devices.Find(device => device.Name == name);
            bool returnValue = false;
            if (found != null)
            {
                found.Enabled = item.Enabled;
                found.Name = item.Name;
                returnValue = true;
            }
            return returnValue;
        }

        public int UpdateAll(string name, IDevice item)
        {
            List<IDevice> found = _dataContext.Devices.FindAll(device => device.Name == name);
            foreach (var d in found)
            {
                d.Enabled = item.Enabled;
                d.Name = item.Name;
            }
            return found.Count;
        }

        public bool SetState(int id, bool enabled)
        {
            IDevice device = Get(id);
            bool returnValue = false;
            if (device != null)
            {
                device.Enabled = enabled;
                returnValue = true;
            }

            return returnValue;
        }

        public bool SetStateFirst(string name, bool enabled)
        {
            IDevice device = Get(name);
            bool returnValue = false;
            if (device != null)
            {
                device.Enabled = enabled;
                returnValue = true;
            }

            return returnValue;
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
            bool returnValue = false;
            if (device != null)
            {
                device.Enabled = !device.Enabled;
                returnValue = true;
            }

            return returnValue;
        }

        public bool ToggleFirst(string name)
        {
            IDevice device = Get(name);
            bool returnValue = false;
            if (device != null)
            {
                device.Enabled = !device.Enabled;
                returnValue = true;
            }

            return returnValue;
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
        #endregion
    }
}
