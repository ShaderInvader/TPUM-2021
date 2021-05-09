using ClientLogicLayer.InternalDTOs;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ClientLogicLayer
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

        public static RoomDTO Map(Room room)
        {
            return new RoomDTO()
            {
                Id = room.Id,
                Name = room.Name
            };
        }

        public static DeviceDTO Map(IDevice device)
        {
            return new DeviceDTO()
            {
                Id = device.Id,
                Name = device.Name,
                Enabled = device.Enabled
            };
        }

        public static IDevice Map(DeviceDTO device)
        {
            return new ExampleDevice()
            {
                Id = device.Id,
                Name = device.Name,
                Enabled = device.Enabled
            };
        }

        public static Room Map(RoomDTO room)
        {
            return new Room()
            {
                Id = room.Id,
                Name = room.Name
            };
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
