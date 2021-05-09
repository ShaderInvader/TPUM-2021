using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(int id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<bool> AddUser(UserDTO userToAdd);
        Task<bool> RemoveUser(int userID);
        Task<bool> LoginUser(string username, string password);
        Task<bool> UpdateUser(int id, UserDTO userData);
    }
}
