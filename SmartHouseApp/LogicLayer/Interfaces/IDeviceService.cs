using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.DTOs;

namespace LogicLayer.Interfaces
{
    public interface IDeviceService
    {
        DeviceDTO GetDevice(int id);
        IEnumerable<DeviceDTO> GetDevices();
        IEnumerable<DeviceDTO> GetDevicesByName(string name);
        bool SetDeviceState(int id, bool state);
        bool AddDevice(DeviceDTO newDevice);
        bool RemoveDevice(DeviceDTO deviceToRemove);
    }
}
