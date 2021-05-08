using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientLogicLayer.InternalDTOs;
using LogicLayer.Interfaces;
using ModelCommon.Interfaces;

namespace ClientLogicLayer.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;

        public event Action DeviceChange;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepo = deviceRepository;
        }

        public DeviceDTO GetDevice(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();

            return Mapper.Map(_deviceRepo.Get(id));
        }

        public async Task<IEnumerable<DeviceDTO>> GetDevices()
        {
            IEnumerable<IDevice> devices = await _deviceRepo.Get();

            List<DeviceDTO> devicesDTOs = new List<DeviceDTO>();
            foreach (var device in devices)
            {
                devicesDTOs.Add(Mapper.Map(device));
            }

            return devicesDTOs;
        }

        public IEnumerable<DeviceDTO> GetDevicesByName(string name)
        {
            IEnumerable<IDevice> devices = _deviceRepo.GetAll(name);
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
                DeviceChange?.Invoke();
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
            DeviceChange?.Invoke();
            return true;
        }

        public bool RemoveDevice(DeviceDTO deviceToRemove)
        {
            bool retVal = false;
            try
            {
                retVal = _deviceRepo.Remove(deviceToRemove.Id);
            }
            catch (InvalidDeviceDataException)
            {
                return false;
            }
            DeviceChange?.Invoke();
            return retVal;
        }
    }
}
