using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.DTOs;

namespace LogicLayer.Interfaces
{
    interface IUserService
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();
        IEnumerable<UserDTO> GetUsersByName(string name);
    }
}
