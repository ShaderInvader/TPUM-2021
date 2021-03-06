using System.Collections.Generic;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _dataContext;
        private readonly object _deviceLock = new object();

        private static DeviceRepository _instance;
        public static DeviceRepository Instance
        {
            get { return _instance ??= new DeviceRepository(); }
            private set => _instance = value;
        }

        public DeviceRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region IDeviceRepository

        public bool Add(IDevice item)
        {
            _dataContext.Devices.Add(item);
            return true;
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

        public int Remove(string name)
        {
            return _dataContext.Devices.RemoveAll(device => device.Name == name);
        }

        public bool Remove(int id)
        {
            return _dataContext.Devices.RemoveAll(device => device.Id == id) > 0;
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

        public bool Toggle(int id)
        {
            IDevice device = Get(id);
            bool returnValue = false;
            if (device != null)
            {
                lock (_deviceLock)
                {
                    device.LastState = device.Enabled;
                    device.Enabled = !device.Enabled;
                }
                returnValue = true;
            }

            return returnValue;
        }

        public bool TurnOffAll()
        {
            List<IDevice> devices = (List<IDevice>)Get();
            foreach (var device in devices)
            {
                lock (_deviceLock)
                {
                    device.LastState = device.Enabled;
                    device.Enabled = false;
                }
            }
            return true;
        }

        public bool ApplyLastStateOnAll()
        {
            List<IDevice> devices = (List<IDevice>)Get();
            foreach (var device in devices)
            {
                lock (_deviceLock)
                {
                    device.Enabled = device.LastState;
                }
            }
            return true;
        }
        #endregion
    }
}
