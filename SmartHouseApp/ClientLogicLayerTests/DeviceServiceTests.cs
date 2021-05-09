using System;
using System.Collections.Generic;
using System.Linq;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.Services;
using ModelCommon;
using ModelCommon.Interfaces;
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
            _deviceRepoMock.Setup(x => x.Get(0)).Returns(new ExampleDevice() { Id = 0, Name = "bulb", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(1)).Returns(new ExampleDevice() { Id = 1, Name = "bulb1", Enabled = true });
            _deviceRepoMock.Setup(x => x.Get(2)).Returns(new ExampleDevice() { Id = 2, Name = "md", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(3)).Returns(new ExampleDevice() { Id = 3, Name = "aaa", Enabled = false });
            _deviceRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // Get everything
            _deviceRepoMock.Setup(x => x.Get()).Returns(new List<IDevice>()
            {
                new ExampleDevice() {Id = 10, Name = "A", Enabled = false},
                new ExampleDevice() {Id = 11, Name = "B", Enabled = true},
                new ExampleDevice() {Id = 12, Name = "C", Enabled = true},
                new ExampleDevice() {Id = 13, Name = "D", Enabled = false},
                new ExampleDevice() {Id = 14, Name = "E", Enabled = false},
                new ExampleDevice() {Id = 15, Name = "F", Enabled = false}
            });

            // Get all
            _deviceRepoMock.Setup(x => x.GetAll("device")).Returns(new List<IDevice>()
            {
                new ExampleDevice() {Id = 100, Name = "device", Enabled = false},
                new ExampleDevice() {Id = 101, Name = "device", Enabled = false},
                new ExampleDevice() {Id = 102, Name = "device", Enabled = false}
            });

            //_deviceRepoMock.SetupRemove()

            dService = new DeviceService(_deviceRepoMock.Object);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual("bulb",dService.GetDevice(0).Name);
            Assert.AreEqual(1, dService.GetDevice(1).Id);   
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
        public void SetDeviceStateTest()
        {
            
        }

        [Test]
        public void AddDeviceTest()
        {

        }

        [Test]
        public void RemoveDeviceTest()
        {
            
        }

        [Test]
        public void ToggleDeviceTest()
        {

        }
    }
}
