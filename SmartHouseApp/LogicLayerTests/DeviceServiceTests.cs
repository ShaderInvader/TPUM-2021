using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using LogicLayer;
using Moq;
using NUnit.Framework;

namespace LogicLayerTests
{
    class DeviceServiceTests
    {
        private Mock<IDeviceRepository> _deviceRepoMock;
        private DeviceService dService;

        [SetUp]
        public void Setup()
        {
            _deviceRepoMock = new Mock<IDeviceRepository>();

            // Get by id
            _deviceRepoMock.Setup(x => x.Get(0)).Returns(new LightBulb() { Id = 0, Name = "bulb", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(1)).Returns(new LightBulb() { Id = 1, Name = "bulb1", Enabled = true });
            _deviceRepoMock.Setup(x => x.Get(2)).Returns(new MotionDetector() { Id = 2, Name = "md", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(3)).Returns(new WallSocket() { Id = 3, Name = "aaa", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // Get everything
            _deviceRepoMock.Setup(x => x.Get()).Returns(new List<IDevice>()
            {
                new LightBulb() {Id = 10, Name = "A", Enabled = false},
                new LightBulb() {Id = 11, Name = "B", Enabled = true},
                new LightBulb() {Id = 12, Name = "C", Enabled = true},
                new MotionDetector() {Id = 13, Name = "D", Enabled = false},
                new MotionDetector() {Id = 14, Name = "E", Enabled = false},
                new WallSocket() {Id = 15, Name = "F", Enabled = false}
            });

            // Get all
            _deviceRepoMock.Setup(x => x.GetAll("device")).Returns(new List<IDevice>()
            {
                new LightBulb() {Id = 100, Name = "device", Enabled = false},
                new MotionDetector() {Id = 101, Name = "device", Enabled = false},
                new WallSocket() {Id = 102, Name = "device", Enabled = false}
            });

            dService = new DeviceService(_deviceRepoMock.Object);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(dService.GetDevice(0).Name, "bulb");
            Assert.AreEqual(dService.GetDevice(1).Id, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => dService.GetDevice(-1));
        }

        [Test]
        public void TestGetAll()
        {
            var devices = dService.GetDevices().ToList();
            Assert.AreEqual(devices.Count, 6);
            Assert.AreEqual(devices[0].Name, "A");
            Assert.AreEqual(devices[1].Enabled, true);
            Assert.AreEqual(devices[2].Id, 12);
        }

        [Test]
        public void TestByGetName()
        {
            var devices = dService.GetDevicesByName("device").ToList();
            Assert.AreEqual(devices.Count, 3);
            Assert.AreEqual(devices[0].Name, "device");
            Assert.AreEqual(devices[1].Name, "device");
            Assert.AreEqual(devices[2].Id, 102);
        }
    }
}
