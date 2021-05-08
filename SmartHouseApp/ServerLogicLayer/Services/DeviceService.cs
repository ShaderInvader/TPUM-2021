using ModelCommon.Interfaces;
using ModelCommon;
using ServerDataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServerDataLayer.Interfaces;

namespace ServerLogicLayer
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository _repoReference = null;

        public DeviceService()
        {
            if(_repoReference == null)
            {
                _repoReference = new DeviceRepository();
                _repoReference.Add(new ExampleDevice() { Id = 0, Name = "Philips Hue Bluetooth White and Color Ambiance Bulb", Enabled = true });
                _repoReference.Add(new ExampleDevice() { Id = 1, Name = "Yeelight Smart LED Bulb", Enabled = true });
                _repoReference.Add(new ExampleDevice() { Id = 2, Name = "Mi Smart Motion Sensor", Enabled = false });
                _repoReference.Add(new ExampleDevice() { Id = 3, Name = "Mi Smart Motion Sensor", Enabled = false });
                _repoReference.Add(new ExampleDevice() { Id = 4, Name = "Dahua's Smart Motion Detection", Enabled = true });
                _repoReference.Add(new ExampleDevice() { Id = 5, Name = "Gosund Smart Socket SP1-C", Enabled = true });
                _repoReference.Add(new ExampleDevice() { Id = 6, Name = "Gosund Smart Socket SP1-C", Enabled = false });
            }
        }

        #region IDeviceService

        public async Task<bool> AddDevice(ExampleDeviceDTO newDevice)
        {
            return await Task.FromResult( _repoReference.Add(Mapper.Map(newDevice)));
        }

        public async Task<ExampleDeviceDTO> GetDevice(int id)
        {
            return await Task.FromResult(Mapper.Map(_repoReference.Get(id)));
        }

        public async Task<ExampleDeviceDTO> GetDevice(string name)
        {
            return await Task.FromResult(Mapper.Map(_repoReference.Get(name)));
        }

        public async Task<IEnumerable<ExampleDeviceDTO>> GetDevices()
        {
            var devices = await _repoReference.Get();
            List<ExampleDeviceDTO> exampleDevices = new List<ExampleDeviceDTO>();
            foreach(var d in devices)
            {
                exampleDevices.Add(Mapper.Map(d));
            }
            return await Task.FromResult(exampleDevices);
        }

        public async Task<IEnumerable<ExampleDeviceDTO>> GetDevicesByName(string name)
        {
            var devices = _repoReference.GetAll(name);
            List<ExampleDeviceDTO> exampleDevices = new List<ExampleDeviceDTO>();
            foreach (var d in devices)
            {
                exampleDevices.Add(Mapper.Map(d));
            }
            return await Task.FromResult(exampleDevices);
        }

        public async Task<int[]> GetDevicesIds(string name)
        {
            return await Task.FromResult(_repoReference.GetIds(name));
        }

        public async Task<bool> RemoveDevice(int id)
        {
            return await Task.FromResult(_repoReference.Remove(id));
        }

        public async Task<bool> RemoveDevicesByName(string name)
        {
            return await Task.FromResult(_repoReference.Remove(name) > 0);
        }

        public async Task<bool> SetDeviceState(int id, bool state)
        {
            return await Task.FromResult(_repoReference.SetState(id, state));
        }

        public async Task<bool> UpdateDevice(int id, ExampleDeviceDTO deviceNewValues)
        {
            return await Task.FromResult(_repoReference.Update(id, Mapper.Map(deviceNewValues)));
        } 
        #endregion
    }
}
