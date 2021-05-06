using DataLayer;
using System.Collections.Generic;
using ModelCommon;

namespace LogicLayer
{
    public static class RepositoryPlaceholder
    {
        private static readonly DataContext _context = new DataContext();
        private static IDeviceRepository _deviceRepository = null;

        private static INamedRepository<User> _usersRepository = null;

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
    }
}
