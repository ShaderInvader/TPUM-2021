using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;
using LogicLayer.DTOs;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepo;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepo = deviceRepository;
        }

        public DeviceDTO GetDevice(int id)
        {
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
            return _deviceRepo.SetState(id, state);
        }

        public bool AddDevice(DeviceDTO newDevice)
        {
            try 
            {
                _deviceRepo.Add(Mapper.Map(newDevice));
            }
            catch(Exceptions.InvalidDeviceTypeException)
            {
                return false;
            }
            return true;
        }

        public bool RemoveDevice(DeviceDTO deviceToRemove)
        {
            bool retVal = false;
            try
            {
                retVal = _deviceRepo.Remove(Mapper.Map(deviceToRemove));
            }
            catch (Exceptions.InvalidDeviceTypeException)
            {
                return false;
            }
            return retVal;
        }
    }
}
