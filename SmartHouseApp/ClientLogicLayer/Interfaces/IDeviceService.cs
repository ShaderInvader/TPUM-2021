using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientLogicLayer.InternalDTOs;

namespace ClientLogicLayer.Interfaces
{
    public interface IDeviceService
    {
        Task RefreshDevices();
        DeviceDTO GetDevice(int id);
        IEnumerable<DeviceDTO> GetDevices();
        bool SetDeviceState(int id, bool state);
        bool AddDevice(DeviceDTO newDevice);
        bool RemoveDevice(DeviceDTO deviceToRemove);
        public Task ToggleDevice(int selectedDeviceId);

        event Action DeviceChange;
    }
}
