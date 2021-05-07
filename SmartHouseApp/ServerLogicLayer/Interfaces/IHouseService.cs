using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IHouseService
    {
        Task<HouseDTO> GetHouse(int id);
        Task<IEnumerable<HouseDTO>> GetHouses();
        Task<IEnumerable<HouseDTO>> GetHousesByName(string name);
        Task<IEnumerable<DeviceDTO>> GetHouseDevices(HouseDTO house);
        Task<IEnumerable<UserDTO>> GetHouseUsers(HouseDTO house);
        Task<bool> AddHouse(HouseDTO houseToAdd);
        Task<bool> RemoveHouse(HouseDTO houseToRemove);
        Task<bool> UpdateHouse(int id, HouseDTO newHouseValues);
        Task<bool> AddDeviceToHouse(HouseDTO referenceHouse, DeviceDTO newDevice);
        Task<bool> RemoveDeviceFromHouse(HouseDTO referenceHouse, DeviceDTO newDevice);
        Task<bool> AddUserToHouse(HouseDTO referenceHouse, UserDTO newUser);
        Task<bool> RemoveUserFromHouse(HouseDTO referenceHouse, UserDTO userToRemove);
    }
}
