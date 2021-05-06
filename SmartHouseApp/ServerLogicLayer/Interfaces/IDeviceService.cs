using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IDeviceService
    {
        Task<DeviceDTO> GetDevice(int id);
        Task<DeviceDTO> GetDevice(string name);
        Task<IEnumerable<DeviceDTO>> GetDevices();
        Task<IEnumerable<DeviceDTO>> GetDevicesByName(string name);
        Task<bool> SetDeviceState(int id, bool state);
        Task<bool> AddDevice(DeviceDTO newDevice);
        Task<bool> RemoveDevice(DeviceDTO devicetoRemove);
        Task<bool> RemoveDevicesByName(string name);
        Task<int[]> GetDevicesIds(string name);
        Task<bool> UpdateDevice(int id, DeviceDTO deviceNewValues);
    }
}
