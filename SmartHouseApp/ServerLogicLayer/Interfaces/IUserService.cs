using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(int id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<IEnumerable<UserDTO>> GetUsersByName(string name);
        Task<bool> AddUser(UserDTO userToAdd);
        Task<bool> RemoveUser(UserDTO userToRemove);
        Task<bool> LoginUser(string username, string password);
        Task<bool> UpdateUser(int id, UserDTO userData);
    }
}
