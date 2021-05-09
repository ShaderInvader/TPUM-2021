using NUnit.Framework;
using ServerDataLayer;
using ModelCommon;
using ModelCommon.Interfaces;
using System.Collections.Generic;

namespace ServerDataTests
{
    class RoomRepoTest
    {
        private RoomRepository _roomRepo;
        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Rooms.Clear();
            _roomRepo = new RoomRepository();
            _roomRepo.Add(new Room() { Id = 0, Name = "Kitchen", Devices = new List<IDevice>() });
            _roomRepo.Add(new Room() { Id = 1, Name = "Living Room", Devices = new List<IDevice>() });
            _roomRepo.Add(new Room() { Id = 2, Name = "Bathroom", Devices = new List<IDevice>() });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(0, _roomRepo.Get(0).Id);
            Assert.AreEqual("Kitchen", _roomRepo.Get(0).Name);
            Assert.AreEqual(0, _roomRepo.Get(0).Devices.Count);
            var allRooms = (List<Room>)_roomRepo.Get();
            Assert.AreEqual(3, allRooms.Count);

        }

        [Test]
        public void AddRoomTest()
        {
            Assert.AreEqual(true, _roomRepo.Add(new Room() { Id = 3, Name = "Hall", Devices = new List<IDevice>() }));
            Assert.AreEqual("Hall", _roomRepo.Get(3).Name);
            Assert.AreEqual(3, _roomRepo.Get("Hall").Id);

            var allRooms = (List<Room>)_roomRepo.Get();
            Assert.AreEqual(4, allRooms.Count);
        }

        [Test]
        public void RemoveRoomTest()
        {
            Assert.AreEqual(false, _roomRepo.Remove(5));
            Assert.AreEqual(true, _roomRepo.Remove(0));
            var allRooms = (List<Room>)_roomRepo.Get();
            Assert.AreEqual(2, allRooms.Count);
            Assert.AreEqual(null, _roomRepo.Get(0));
        }

        [Test]
        public void UpdateTest()
        {
            Assert.AreEqual(true, _roomRepo.Update(1, new Room() { Id = 1, Name = "Livingroom", Devices = new List<IDevice>()}));
            Assert.AreEqual("Livingroom", _roomRepo.Get(1).Name);
        }

        [Test]
        public void AddRemoveDeviceToRoomTest()
        {
            ExampleDevice dev = new ExampleDevice() { Id = 0 };
            Assert.AreEqual(false, _roomRepo.AddDeviceToRoom(4, dev));
            Assert.AreEqual(true, _roomRepo.AddDeviceToRoom(0, dev));
            Assert.AreEqual(1, _roomRepo.Get(0).Devices.Count);
            Assert.AreEqual(true, _roomRepo.RemoveDeviceFromRoom(0, 0));
            Assert.AreEqual(0, _roomRepo.Get(0).Devices.Count);
        }
    }
}
