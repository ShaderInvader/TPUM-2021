using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IDeviceService
    {
        Task<ExampleDeviceDTO> GetDevice(int id);
        Task<ExampleDeviceDTO> GetDevice(string name);
        Task<IEnumerable<ExampleDeviceDTO>> GetDevices();
        Task<IEnumerable<ExampleDeviceDTO>> GetDevicesByName(string name);
        Task<bool> SetDeviceState(int id, bool state);
        Task<bool> AddDevice(ExampleDeviceDTO newDevice);
        Task<bool> RemoveDevice(ExampleDeviceDTO devicetoRemove);
        Task<bool> RemoveDevicesByName(string name);
        Task<int[]> GetDevicesIds(string name);
        Task<bool> UpdateDevice(int id, ExampleDeviceDTO deviceNewValues);
    }
}
