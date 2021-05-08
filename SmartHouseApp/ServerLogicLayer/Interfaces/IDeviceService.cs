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
        Task<bool> ToggleDevice(int id);
        Task<bool> AddDevice(ExampleDeviceDTO newDevice);
        Task<bool> RemoveDevice(int id);
        Task<bool> RemoveDevicesByName(string name);
        Task<int[]> GetDevicesIds(string name);
        Task<bool> UpdateDevice(int id, ExampleDeviceDTO deviceNewValues);
        Task<bool> TurnOffAllDevices();
    }
}
