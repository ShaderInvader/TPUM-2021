using NUnit.Framework;
using Moq;
using ServerDataLayer;
using ModelCommon;
using System;
using ModelCommon.Interfaces;
using System.Collections.Generic;
using ServerLogicLayer;

namespace ServerLogicTests
{
    public class DeviceServiceTest
    {
        private Mock<IDeviceRepository> _mockRepo;
        private DeviceService _service;
        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IDeviceRepository>();
            // Get by id
            _mockRepo.Setup(x => x.Get(0)).Returns(new ExampleDevice() { Id = 0, Name = "Light Bulb", Enabled = false });
            _mockRepo.Setup(x => x.Get(1)).Returns(new ExampleDevice() { Id = 1, Name = "Motion Detector", Enabled = true });
            _mockRepo.Setup(x => x.Get(2)).Returns(new ExampleDevice() { Id = 2, Name = "Wall Socket", Enabled = false });
            _mockRepo.Setup(x => x.Get(3)).Returns(new ExampleDevice() { Id = 3, Name = "Light Bulb", Enabled = false });
            _mockRepo.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // Get everything
            _mockRepo.Setup(x => x.Get()).Returns(new List<IDevice>()
            {
                new ExampleDevice() {Id = 10, Name = "A", Enabled = false},
                new ExampleDevice() {Id = 11, Name = "B", Enabled = true},
                new ExampleDevice() {Id = 12, Name = "C", Enabled = true},
                new ExampleDevice() {Id = 13, Name = "D", Enabled = false},
                new ExampleDevice() {Id = 14, Name = "E", Enabled = false},
                new ExampleDevice() {Id = 15, Name = "F", Enabled = false}
            });

            //Add mock
            _mockRepo.Setup(x => x.Add(new ExampleDevice() { Id = 0, Name = "A", Enabled = false })).Returns(false);

            //Remove mock
            _mockRepo.Setup(x => x.Remove(1)).Returns(true);
            _mockRepo.Setup(x => x.Remove(3)).Returns(false);

            //Toggle device test
            _mockRepo.Setup(x => x.Toggle(0)).Returns(true);
            _mockRepo.Setup(x => x.Toggle(3)).Returns(false);

            //TurnOffAllDevices
            _mockRepo.Setup(x => x.TurnOffAll()).Returns(true);

            //Update test
            _mockRepo.Setup(x => x.Update(1, new ExampleDevice() { Id = -1, Name = "B", Enabled = true })).Returns(false);

            _service = new DeviceService(_mockRepo.Object);
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("Light Bulb", _service.GetDevice(0).Result.Name);
            Assert.AreEqual(false, _service.GetDevice(2).Result.Enabled);
            Assert.Throws<System.AggregateException>(() => { _ = _service.GetDevice(4).Result; });
            Assert.AreEqual(6, ((List<ExampleDeviceDTO>)_service.GetDevices().Result).Count);
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(false, _service.AddDevice(new ExampleDeviceDTO() { Id = 0, Name = "A", Enabled = false }).Result);
            Assert.AreEqual(false, _service.AddDevice(new ExampleDeviceDTO() { Id = -1, Name = "B", Enabled = true }).Result);
        }

        [Test]
        public void ToggleDeviceTest()
        {
            Assert.AreEqual(true, _service.ToggleDevice(0).Result);
            Assert.AreEqual(false, _service.ToggleDevice(3).Result);
        }

        [Test]
        public void TurnOffAllDevicesTest()
        {
            Assert.AreEqual(true, _service.TurnOffAllDevices().Result);
        }

        [Test]
        public void UpdateTest()
        {
            Assert.AreEqual(false, _service.UpdateDevice(1, new ExampleDeviceDTO() { Id = -1, Name = "B", Enabled = true }).Result);
        }
    }
}