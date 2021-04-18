using DataLayer.Devices;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    public static class RepositoryMock
    {
        private static readonly DataContext _context = new DataContext();
        private static IDeviceRepository _deviceRepository = null;

        private static INamedRepository<User> _usersRepository = null;
        private static INamedRepository<Room> _roomsRepository = null;

        public static IDeviceRepository GetDeviceRepository()
        {
            if(_deviceRepository == null)
            {
                _deviceRepository = new DeviceRepository(_context);
                _deviceRepository.Add(new LightBulb() { Id = 0, Name = "Philips Hue Bluetooth White and Color Ambiance Bulb", Enabled = true });
                _deviceRepository.Add(new LightBulb() { Id = 1, Name = "Yeelight Smart LED Bulb", Enabled = true });
                _deviceRepository.Add(new MotionDetector() { Id = 2, Name = "Mi Smart Motion Sensor", Enabled = false });
                _deviceRepository.Add(new MotionDetector() { Id = 3, Name = "Mi Smart Motion Sensor", Enabled = false });
                _deviceRepository.Add(new MotionDetector() { Id = 4, Name = "Dahua's Smart Motion Detection", Enabled = true });
                _deviceRepository.Add(new WallSocket() { Id = 5, Name = "Gosund Smart Socket SP1-C", Enabled = true });
                _deviceRepository.Add(new WallSocket() { Id = 6, Name = "Gosund Smart Socket SP1-C", Enabled = false });
            }
            return _deviceRepository;
        }

        public static INamedRepository<User> GetUsersRepository()
        {
            if (_usersRepository == null)
            {
                _usersRepository = new UserRepository(_context);
                _usersRepository.Add(new User() {Name="Johnny123", FirstName="John", LastName="Audio", Email="Johnny123@example.com", Id=1, Password="password"});
            }
            return _usersRepository;
        }

        public static INamedRepository<Room> GetRoomsRepository()
        {
            if(_roomsRepository == null)
            {
                _roomsRepository = new RoomRepository(_context);
                _roomsRepository.Add(new Room() { Id = 0, Name = "Living Room", Description = "", Devices = new List<IDevice>() });
                _roomsRepository.Add(new Room() { Id = 1, Name = "Kitchen", Description = "", Devices = new List<IDevice>() });
                var devices = new List<IDevice>(GetDeviceRepository().Get());
                for (int i = 0; i < devices.Count; ++i)
                {
                    if(i % 2 == 0)
                    {
                        _roomsRepository.Get(0).Devices.Add(GetDeviceRepository().Get(i));
                    }
                    else
                    {
                        _roomsRepository.Get(1).Devices.Add(GetDeviceRepository().Get(i));
                    }
                }
            }
            return _roomsRepository;
        }
    }
}
