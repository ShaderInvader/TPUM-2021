using System.Collections.Generic;
using System.Threading.Tasks;
using ServerDataLayer;

namespace ServerLogicLayer
{
    public class UserService : IUserService
    {
        private readonly INamedRepository<User> _repoReference;

        public UserService()
        {
            if(_repoReference == null)
            {
                _repoReference = new UserRepository();
                _repoReference.Add(new User() { Name = "Johnny123", FirstName = "John", LastName = "Audio", Email = "Johnny123@example.com", Id = 1, Password = "password"});
            }
        }

        public UserService(INamedRepository<User> repository)
        {
            _repoReference = repository;
        }

        private async Task<IEnumerable<UserDTO>> GetUsersByName(string name)
        {
            var users = _repoReference.GetAll(name);
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var u in users)
            {
                usersDTO.Add(Mapper.Map(u));
            }
            return await Task.FromResult(usersDTO);
        }

        #region IUserService
        public async Task<bool> AddUser(UserDTO userToAdd)
        {
            return await Task.FromResult(_repoReference.Add(Mapper.Map(userToAdd)));
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return await Task.FromResult(Mapper.Map(_repoReference.Get(id)));
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _repoReference.Get();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var u in users)
            {
                usersDTO.Add(Mapper.Map(u));
            }
            return await Task.FromResult(usersDTO);
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            List<UserDTO> users = new List<UserDTO>(await GetUsersByName(username));
            bool returnValue = false;
            if (users.Count == 1)
            {
                returnValue = users[0].Password.CompareTo(password) == 0;
            }
            return await Task.FromResult(returnValue);
        }

        public async Task<bool> RemoveUser(int id)
        {
            return await Task.FromResult(_repoReference.Remove(id));
        }

        public async Task<bool> UpdateUser(int id, UserDTO userData)
        {
            return await Task.FromResult(_repoReference.Update(id, Mapper.Map(userData)));
        } 
        
        #endregion
    }
}
