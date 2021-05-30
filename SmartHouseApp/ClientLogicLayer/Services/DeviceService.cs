using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.Interfaces;
using ClientLogicLayer.InternalDTOs;

namespace ClientLogicLayer.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;

        public event Action DevicesChange;
        public event Action<DeviceDTO> OnDeviceChanged;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepo = deviceRepository;
            _deviceRepo.DataChanged += DevicesChangedInvoke;
            _deviceRepo.OnDeviceChanged += OnDeviceChangedInvoke;
        }

        public void DevicesChangedInvoke()
        {
            DevicesChange?.Invoke();
        }

        public void OnDeviceChangedInvoke(IDevice device)
        {
            OnDeviceChanged.Invoke(Mapper.Map(device));
        }

        public async Task RefreshDevices()
        {
            await _deviceRepo.Refresh();
        }

        public async Task SubscribeDevice(DeviceDTO device)
        {
            await _deviceRepo.SubscribeDevice(Mapper.Map(device));
        }

        public async Task DisposeDevice(DeviceDTO device)
        {
            await _deviceRepo.DisposeDevice(Mapper.Map(device));
        }

        public DeviceDTO GetDevice(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            return Mapper.Map(_deviceRepo.Get(id));
        }

        public IEnumerable<DeviceDTO> GetDevices()
        {
            IEnumerable<IDevice> devices = _deviceRepo.Get();

            List<DeviceDTO> devicesDTOs = new List<DeviceDTO>();
            foreach (var device in devices)
            {
                devicesDTOs.Add(Mapper.Map(device));
            }

            return devicesDTOs;
        }

        public bool SetDeviceState(int id, bool state)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            bool methodRetVal = _deviceRepo.SetState(id, state);
            if (methodRetVal)
            {
                DevicesChange?.Invoke();
            }
            return methodRetVal;
        }

        public bool AddDevice(DeviceDTO newDevice)
        {
            DeviceField invalidFields = DeviceField.None;

            if (newDevice.Id < 0)
            {
                invalidFields |= DeviceField.Id;
            }

            if (newDevice.Name == "")
            {
                invalidFields |= DeviceField.Name;
            }

            if (invalidFields != DeviceField.None)
            {
                throw new InvalidDeviceDataException(invalidFields);
            }

            _deviceRepo.Add(Mapper.Map(newDevice));
            DevicesChange?.Invoke();
            return true;
        }

        public bool RemoveDevice(DeviceDTO deviceToRemove)
        {
            bool retVal;
            try
            {
                retVal = _deviceRepo.Remove(deviceToRemove.Id);
            }
            catch (InvalidDeviceDataException)
            {
                return false;
            }
            DevicesChange?.Invoke();
            return retVal;
        }

        public async Task ToggleDevice(int selectedDeviceId)
        {
            await _deviceRepo.Toggle(selectedDeviceId);
        }
    }
}
