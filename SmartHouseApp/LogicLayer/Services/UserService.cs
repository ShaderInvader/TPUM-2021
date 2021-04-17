﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Interfaces;
using LogicLayer.DTOs;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
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
            return Mapper.Map(_userRepo.Get(id));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            IEnumerable<User> users = _userRepo.Get();
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
    }
}