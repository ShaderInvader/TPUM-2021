using ModelCommon;
using ServerDataLayer;
using System.Collections.Generic;
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

        public DeviceService(IDeviceRepository repository)
        {
            _repoReference = repository;
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

        public async Task<IEnumerable<ExampleDeviceDTO>> GetDevices()
        {
            var devices = _repoReference.Get();
            List<ExampleDeviceDTO> exampleDevices = new List<ExampleDeviceDTO>();
            foreach(var d in devices)
            {
                exampleDevices.Add(Mapper.Map(d));
            }
            return await Task.FromResult(exampleDevices);
        }

        public async Task<bool> RemoveDevice(int id)
        {
            return await Task.FromResult(_repoReference.Remove(id));
        }

        public async Task<bool> ToggleDevice(int id)
        {
            return await Task.FromResult(_repoReference.Toggle(id));
        }

        public async Task<bool> UpdateDevice(int id, ExampleDeviceDTO deviceNewValues)
        {
            return await Task.FromResult(_repoReference.Update(id, Mapper.Map(deviceNewValues)));
        }

        public async Task<bool> TurnOffAllDevices()
        {
            return await Task.FromResult(_repoReference.TurnOffAll());
        }

        public async Task<bool> TurnOnLastDevices()
        {
            return await Task.FromResult(_repoReference.ApplyLastStateOnAll());
        }
        #endregion
    }
}
