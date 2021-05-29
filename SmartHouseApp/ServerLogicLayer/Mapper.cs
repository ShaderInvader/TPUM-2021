using System;
using System.Collections.Generic;
using ServerDataLayer;
using ServerDataLayer.Interfaces;

namespace ServerLogicLayer
{
    public class Mapper
    {
        public static ExampleDeviceDTO Map(IDevice device)
        {
            return new ExampleDeviceDTO
            {
                Name = device.Name,
                Id = device.Id,
                Enabled = device.Enabled
            };
        }

        public static LocationDTO Map(ILocation location)
        {
            return new LocationDTO
            {
                Longitude = location.Longitude,
                Latitude = location.Latitude
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
                Coordinates = Map(user.Coordinates),
                Password = user.Password
            };
        }

        public static RoomDTO Map(Room house)
        {
            return new RoomDTO
            {
                Id = house.Id,
                Name = house.Name,
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
                Coordinates = Map(userDto.Coordinates),
                Password = userDto.Password
            };
        }

        public static ILocation Map(LocationDTO location)
        {
            return new Location
            {
                Longitude = location.Longitude,
                Latitude = location.Latitude
            };
        }

        public static Room Map(RoomDTO houseDto)
        {
            return new Room
            {
                Id = houseDto.Id,
                Devices = houseDto.Devices,
                Name = houseDto.Name
            };
        }

        public static IDevice Map(ExampleDeviceDTO deviceDTO)
        {
            IDevice device = new ExampleDevice
            {
                Id = deviceDTO.Id,
                Name = deviceDTO.Name,
                Enabled = deviceDTO.Enabled
            };
            return device;
        }
    }
}
