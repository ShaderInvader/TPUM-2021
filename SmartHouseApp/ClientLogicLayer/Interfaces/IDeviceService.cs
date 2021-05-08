using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClientLogicLayer.InternalDTOs;

namespace LogicLayer.Interfaces
{
    public interface IDeviceService
    {
        DeviceDTO GetDevice(int id);
        Task<IEnumerable<DeviceDTO>> GetDevices();
        IEnumerable<DeviceDTO> GetDevicesByName(string name);
        bool SetDeviceState(int id, bool state);
        bool AddDevice(DeviceDTO newDevice);
        bool RemoveDevice(DeviceDTO deviceToRemove);

        event Action DeviceChange;
    }
}
