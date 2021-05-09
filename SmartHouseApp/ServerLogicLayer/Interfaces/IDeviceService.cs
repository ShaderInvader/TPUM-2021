using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IDeviceService
    {
        Task<ExampleDeviceDTO> GetDevice(int id);
        Task<IEnumerable<ExampleDeviceDTO>> GetDevices();
        Task<bool> ToggleDevice(int id);
        Task<bool> AddDevice(ExampleDeviceDTO newDevice);
        Task<bool> RemoveDevice(int id);
        Task<bool> UpdateDevice(int id, ExampleDeviceDTO deviceNewValues);
        Task<bool> TurnOffAllDevices();
        Task<bool> TurnOnLastDevices();
    }
}
