using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;
using ModelCommon;

namespace ServerLogicLayer
{
    public class Mapper
    {
        public static DeviceDTO Map(IDevice device)
        {
            return new DeviceDTO
            {
                Name = device.Name,
                Id = device.Id,
                Type = device.Type,
                Enabled = device.Enabled
            };
        }

        public static UserDTO Map(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = new Tuple<double, double>(user.Location.Item1, user.Location.Item2),
                Password = user.Password
            };
        }

        public static HouseDTO Map(House house)
        {
            return new HouseDTO
            {
                Id = house.Id,
                Name = house.Name,
                Location = new Tuple<double, double>(house.Location.Item1, house.Location.Item2),
                Devices = new List<IDevice>(house.Devices)
            };
        }

        public static User Map(UserDTO userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Location = new Tuple<double, double>(userDto.Location.Item1, userDto.Location.Item2),
                Password = userDto.Password
            };
        }

        public static House Map(HouseDTO houseDto)
        {
            return new House
            {
                Id = houseDto.Id,
                Devices = houseDto.Devices,
                Location = new Tuple<double, double>(houseDto.Location.Item1, houseDto.Location.Item2),
                Name = houseDto.Name
            };
        }

        public static IDevice Map(DeviceDTO deviceDTO)
        {
            IDevice device;
            if(string.Compare(deviceDTO.Type, "LightBulb") == 0)
            {
                device = new LightBulb
                {
                    Name = deviceDTO.Name,
                    Id = deviceDTO.Id,
                    Enabled = deviceDTO.Enabled
                };
            }
            else if (string.Compare(deviceDTO.Type, "MotionDetector") == 0)
            {
                device = new MotionDetector
                {
                    Name = deviceDTO.Name,
                    Id = deviceDTO.Id,
                    Enabled = deviceDTO.Enabled
                };
            }
            else
            {
                device = new WallSocket
                {
                    Name = deviceDTO.Name,
                    Id = deviceDTO.Id,
                    Enabled = deviceDTO.Enabled
                };
            }
            return device;
        }
    }
}
