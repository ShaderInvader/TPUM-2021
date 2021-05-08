using System;
using System.Collections.Generic;
using System.Linq;
using ClientLogicLayer;
using ClientLogicLayer.InternalDTOs;
using LogicLayer.Interfaces;
using ModelCommon;
using ModelCommon.Interfaces;

namespace LogicLayer
{
    public class UserService : IUserService
    {
        private readonly INamedRepository<User> _userRepo;

        public UserService(INamedRepository<User> userRepository)
        {
            _userRepo = userRepository;
        }

        public UserDTO GetUser(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return Mapper.Map(_userRepo.Get(id));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<User> users = _userRepo.Get().Result;
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(Mapper.Map(user));
            }

            return userDTOs;
        }

        public IEnumerable<UserDTO> GetUsersByName(string name)
        {
            IEnumerable<User> users = _userRepo.GetAll(name);
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(Mapper.Map(user));
            }

            return userDTOs;
        }

        public bool AddUser(UserDTO newUser)
        {
           _userRepo.Add(Mapper.Map(newUser));
            return true;
        }

        public bool RemoveUser(UserDTO userToRemove)
        {
            return _userRepo.Remove(userToRemove.Id) > 0;
        }

        public bool LoginUser(string username, string password)
        {
            var users = GetUsersByName(username).ToList();
            // TODO: add proper password validation
            if (users.Count() == 1)
            {
                if (password == "admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new UserNotFoundException(username);
            }
        }
    }
}
