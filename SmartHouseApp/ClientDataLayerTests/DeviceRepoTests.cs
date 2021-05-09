using System.Linq;
using ClientDataLayer;
using ClientDataLayer.Interfaces;
using ModelCommon;
using Moq;
using NUnit.Framework;

namespace DataLayerTests
{
    public class DeviceRepoTests
    {
        private DeviceRepository _dRepo;

        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Devices.Clear();
            DataContext.Instance.Devices.Add(new ExampleDevice() { Enabled = false, Id = 0, LastState = false, Name = "Device0" });
            DataContext.Instance.Devices.Add(new ExampleDevice() { Enabled = true, Id = 1, LastState = false, Name = "Device1" });
            DataContext.Instance.Devices.Add(new ExampleDevice() { Enabled = false, Id = 2, LastState = true, Name = "Device2" });
            DataContext.Instance.Devices.Add(new ExampleDevice() { Enabled = true, Id = 3, LastState = true, Name = "Device3" });
            DataContext.Instance.Devices.Add(new ExampleDevice() { Enabled = false, Id = 4, LastState = true, Name = "Device3" });
            _dRepo = new DeviceRepository();
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(0, _dRepo.Get(0).Id);
            Assert.AreEqual(1, _dRepo.Get("Device1").Id);
            Assert.AreEqual(true, _dRepo.Get(3).Enabled);
            var all = _dRepo.Get().ToList();
            Assert.AreEqual("Device0", all[0].Name);
            Assert.AreEqual("Device1", all[1].Name);
            Assert.AreEqual("Device2", all[2].Name);
            Assert.AreEqual("Device3", all[3].Name);
        }

        [Test]
        public void GetAllTest()
        {
            var all = _dRepo.GetAll("Device3").ToList();
            Assert.AreEqual(2, all.Count);
            Assert.AreEqual(3, all[0].Id);
            Assert.AreEqual(4, all[1].Id);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(1, _dRepo.Remove("Device0"));
            Assert.AreEqual(true, _dRepo.Remove(1));
            var all = _dRepo.Get().ToList();
            Assert.AreEqual(3, all.Count);
            Assert.AreEqual(2, all[0].Id);
            Assert.AreEqual(3, all[1].Id);
            Assert.AreEqual(4, all[2].Id);
        }
    }
}