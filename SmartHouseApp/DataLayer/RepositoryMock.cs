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

        public static IDeviceRepository GetDeviceRepository()
        {
            if(_deviceRepository == null)
            {
                _deviceRepository = new DeviceRepository(_context);
                _deviceRepository.Add(new LightBulb() { Id = 1, Name = "Philips Hue Bluetooth White and Color Ambiance Bulb", Enabled = true });
                _deviceRepository.Add(new LightBulb() { Id = 2, Name = "Yeelight Smart LED Bulb", Enabled = true });
                _deviceRepository.Add(new MotionDetector() { Id = 3, Name = "Mi Smart Motion Sensor", Enabled = false });
                _deviceRepository.Add(new MotionDetector() { Id = 4, Name = "Mi Smart Motion Sensor", Enabled = false });
                _deviceRepository.Add(new MotionDetector() { Id = 5, Name = "Dahua's Smart Motion Detection", Enabled = true });
                _deviceRepository.Add(new WallSocket() { Id = 6, Name = "Gosund Smart Socket SP1-C", Enabled = true });
                _deviceRepository.Add(new WallSocket() { Id = 7, Name = "Gosund Smart Socket SP1-C", Enabled = false });
            }
            return _deviceRepository;
        }
    }
}
