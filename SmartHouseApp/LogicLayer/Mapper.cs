﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Interfaces;
using LogicLayer.DTOs;

namespace LogicLayer
{
    public static class Mapper
    {
        public static UserDTO Map(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static DeviceDTO Map(IDevice device)
        {
            return new DeviceDTO()
            {
                Id = device.Id,
                Name = device.Name,
                Enabled = device.Enabled,
                Type = device.GetType().ToString()
            };
        }

        public static RoomDTO Map(Room room)
        {
            return new RoomDTO()
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description
            };
        }

        public static HouseDTO Map(House house)
        {
            return new HouseDTO()
            {
                Id = house.Id,
                Name = house.Name
            };
        }
    }
}