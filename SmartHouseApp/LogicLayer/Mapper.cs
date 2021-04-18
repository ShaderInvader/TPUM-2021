using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Devices;
using LogicLayer.DTOs;
using LogicLayer.Exceptions;

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
            string type = device.GetType().ToString();
            var names = type.Split('.');
            return new DeviceDTO()
            {
                Id = device.Id,
                Name = device.Name,
                Enabled = device.Enabled,
                Type = names[^1]
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

        public static IDevice Map(DeviceDTO device)
        {
            if (device.Type.Equals("LightBulb"))
            {
                return new LightBulb()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Enabled = device.Enabled
                };
            }
            else if(device.Type.Equals("MotionDetector"))
            {
                return new MotionDetector()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Enabled = device.Enabled
                };
            }
            else if(device.Type.Equals("WallSocket"))
            {
                return new WallSocket()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Enabled = device.Enabled
                };
            }
            throw new Exceptions.InvalidDeviceDataException(DeviceField.Type);
        }

        public static User Map(UserDTO user)
        {
            return new User() 
            { 
                Id = user.Id, 
                Email = user.Email, 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Name = user.Name, 
                Password = user.Password 
            };
        }
    }
}
