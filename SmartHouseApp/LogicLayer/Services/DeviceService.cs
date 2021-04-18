using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;
using LogicLayer.DTOs;
using LogicLayer.Exceptions;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
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
            DeviceField invaildFields = DeviceField.None;

            if (newDevice.Id < 0)
            {
                invaildFields |= DeviceField.Id;
            }
            
            if (!(newDevice.Type == "LightBulb" ||
                 newDevice.Type == "MotionDetector" ||
                 newDevice.Type == "WallSocket"))
            {
                invaildFields |= DeviceField.Type;
            }

            if (newDevice.Name == "")
            {
                invaildFields |= DeviceField.Name;
            }

            if (invaildFields != DeviceField.None)
            {
                throw new InvalidDeviceDataException(invaildFields);
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
                retVal = _deviceRepo.Remove(deviceToRemove.Id) > 0;
            }
            catch (Exceptions.InvalidDeviceDataException)
            {
                return false;
            }
            DeviceChange?.Invoke();
            return retVal;
        }
    }
}
