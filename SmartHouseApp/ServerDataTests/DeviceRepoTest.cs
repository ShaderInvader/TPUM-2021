using NUnit.Framework;
using ServerDataLayer;
using ModelCommon;
using ModelCommon.Interfaces;
using System.Collections.Generic;

namespace ServerDataTests
{
    public class DeviceRepoTests
    {
        private DeviceRepository _deviceRepo;
        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Devices.Clear();
            _deviceRepo = new DeviceRepository();
            _deviceRepo.Add(new ExampleDevice { Id = 0, Name = "Light Bulb", Enabled = true });
            _deviceRepo.Add(new ExampleDevice { Id = 1, Name = "Wall Socket", Enabled = false });
            _deviceRepo.Add(new ExampleDevice { Id = 2, Name = "Light Bulb", Enabled = false });
            _deviceRepo.Add(new ExampleDevice { Id = 3, Name = "Motion Detector", Enabled = true });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("Motion Detector", _deviceRepo.Get(3).Name);
            Assert.AreEqual(1, _deviceRepo.Get("Wall Socket").Id);
            Assert.AreEqual(false, _deviceRepo.Get(1).Enabled);
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            Assert.AreEqual(4, allDevices.Count);
        }

        [Test]
        public void GetAllTest()
        {
            var allBulbs = (List<IDevice>)_deviceRepo.GetAll("Light Bulb");
            Assert.AreEqual(2, allBulbs.Count);
            Assert.AreEqual(0, allBulbs[0].Id);
            Assert.AreEqual(false, allBulbs[1].Enabled);
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(true, _deviceRepo.Add(new ExampleDevice {Id = 4, Name = "Motion Detector", Enabled = false }));
            Assert.AreEqual("Motion Detector", _deviceRepo.Get(4).Name);
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            Assert.AreEqual(5, allDevices.Count);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(false, _deviceRepo.Remove(5));
            Assert.AreEqual(true, _deviceRepo.Remove(0));
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            Assert.AreEqual(3, allDevices.Count);
            Assert.AreEqual(1, allDevices[0].Id);
        }

        [Test]
        public void RemoveByNameTest()
        {
            Assert.AreEqual(2, _deviceRepo.Remove("Light Bulb"));
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            Assert.AreEqual(2, allDevices.Count);
            Assert.AreEqual(1, allDevices[0].Id);
        }

        [Test]
        public void UpdateTest()
        {
            Assert.AreEqual(true, _deviceRepo.Update(0, new ExampleDevice() { Id = 0, Name = "Wall Socket", Enabled = false }));
            Assert.AreEqual("Wall Socket", _deviceRepo.Get(0).Name);
            Assert.AreEqual(false, _deviceRepo.Get(0).Enabled);
        }

        [Test]
        public void TurnOffAllTest()
        {
            _deviceRepo.TurnOffAll();
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            foreach(var d in allDevices)
            {
                Assert.AreEqual(false, d.Enabled);
            }
        }

        [Test]
        public void ApplyLastStateOnAllTest()
        {
            _deviceRepo.TurnOffAll();
            var allDevices = (List<IDevice>)_deviceRepo.Get();
            foreach (var d in allDevices)
            {
                Assert.AreEqual(false, d.Enabled);
            }
            _deviceRepo.ApplyLastStateOnAll();
            Assert.AreEqual(true, _deviceRepo.Get(0).Enabled);
            Assert.AreEqual(false, _deviceRepo.Get(1).Enabled);
            Assert.AreEqual(false, _deviceRepo.Get(2).Enabled);
            Assert.AreEqual(true, _deviceRepo.Get(3).Enabled);

        }

        [Test]
        public void ToggleTest()
        {
            Assert.AreEqual(false, _deviceRepo.Toggle(7));
            Assert.AreEqual(true, _deviceRepo.Toggle(0));
            Assert.AreEqual(false, _deviceRepo.Get(0).Enabled);
        }
    }
}