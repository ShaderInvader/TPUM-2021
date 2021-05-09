using System.Collections.Generic;
using ClientLogicLayer.InternalDTOs;

namespace LogicLayer.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();
        bool AddUser(UserDTO newUser);
        bool RemoveUser(UserDTO userToRemove);
        bool LoginUser(string username, string password);
    }
}
