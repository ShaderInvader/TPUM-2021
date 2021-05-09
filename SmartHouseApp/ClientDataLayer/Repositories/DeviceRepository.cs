using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ClientDataLayer
{
    public class DeviceRepository : IDeviceRepository
    {
        private static DeviceRepository _instance;
        public static DeviceRepository Instance
        {
            get { return _instance ??= new DeviceRepository(); }
            private set => _instance = value;
        }

        private readonly DataContext _dataContext;

        public DeviceRepository()
        {
            _dataContext = DataContext.Instance;
            _dataContext.DevicesChanged += DataChangedInvoke;
        }

        private void DataChangedInvoke()
        {
            DataChanged?.Invoke();
        }

        public event Action DataChanged;

        public IEnumerable<IDevice> Get()
        {
            return _dataContext.Devices;
        }

        public async Task Refresh()
        {
            await _dataContext.RequestDataUpdate();
        }

        public IDevice Get(int id)
        {
            return _dataContext.Devices.Find(device => device.Id == id);
        }

        public async Task<bool> Add(IDevice item)
        {
            string addDeviceRequest = "AddDevice";
            addDeviceRequest += JsonSerializer.Serialize((ExampleDevice)item);

            await _dataContext.RequestWithConfirmation(addDeviceRequest);
            await _dataContext.RequestDataUpdate();

            return await Task.FromResult(true);
        }

        public bool Remove(int id)
        {
            return _dataContext.Devices.RemoveAll(device => device.Id == id) > 0;
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

        public int Remove(string name)
        {
            return _dataContext.Devices.RemoveAll(device => device.Name == name);
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

        public async Task<bool> Toggle(int id)
        {
            await _dataContext.RequestWithConfirmation($"ToggleDevice:{id}");
            await _dataContext.RequestDataUpdate();
            return await Task.FromResult(true);
        }
    }
}
