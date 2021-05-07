using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using ModelCommon;
using ModelCommon.Interfaces;

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

        public static HouseDTO Map(Room house)
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
                return new ExampleDevice()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Enabled = device.Enabled
                };
            }
            throw new InvalidDeviceDataException(DeviceField.Type);
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
