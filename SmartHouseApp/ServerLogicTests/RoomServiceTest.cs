using NUnit.Framework;
using Moq;
using ServerDataLayer;
using System;
using System.Collections.Generic;
using ServerDataLayer.Interfaces;
using ServerLogicLayer;

namespace ServerLogicTests
{
    class RoomServiceTest
    {
        private Mock<IRoomRepository> _mockRepo;
        private RoomService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IRoomRepository>();

            // Get by id
            _mockRepo.Setup(x => x.Get(0)).Returns(new Room() { Id = 0, Name = "Loft", Devices = new List<IDevice>()});
            _mockRepo.Setup(x => x.Get(1)).Returns(new Room() { Id = 1, Name = "Mieszkanie", Devices = new List<IDevice>() });
            _mockRepo.Setup(x => x.Get(2)).Returns(new Room() { Id = 2, Name = "Dom", Devices = new List<IDevice>() });
            _mockRepo.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // Get everything
            _mockRepo.Setup(x => x.Get()).Returns(new List<Room>()
            {
                new Room() {Id = 10, Name = "A", Devices = new List<IDevice>()},
                new Room() {Id = 11, Name = "B", Devices = new List<IDevice>()},
                new Room() {Id = 12, Name = "C", Devices = new List<IDevice>()},
                new Room() {Id = 13, Name = "D", Devices = new List<IDevice>()},
                new Room() {Id = 14, Name = "E", Devices = new List<IDevice>()}
            });

            //Add mock
            _mockRepo.Setup(x => x.Add(new Room() { Id = 0, Name = "A", Devices = new List<IDevice>() })).Returns(false);

            //Remove mock
            _mockRepo.Setup(x => x.Remove(1)).Returns(true);
            _mockRepo.Setup(x => x.Remove(3)).Returns(false);

            //Update test
            _mockRepo.Setup(x => x.Update(1, new Room() { Id = -1, Name = "B", Devices = new List<IDevice>() })).Returns(false);

            _service = new RoomService(_mockRepo.Object);
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("Loft", _service.GetRoom(0).Result.Name);
            Assert.AreEqual(2, _service.GetRoom(2).Result.Id);
            Assert.AreEqual(5, ((List<RoomDTO>)_service.GetRooms().Result).Count);
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(false, _service.AddRoom(new RoomDTO() { Id = 0, Name = "A", Devices = new List<IDevice>() }).Result);
            Assert.AreEqual(false, _service.AddRoom(new RoomDTO() { Id = -1, Name = "B", Devices = new List<IDevice>() }).Result);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(true, _service.RemoveRoom(new RoomDTO() { Id = 1, Name = "A" }).Result);
            Assert.AreEqual(false, _service.RemoveRoom(new RoomDTO() { Id = 3, Name = "C" }).Result);
        }

        [Test]
        public void UpdateTest()
        {
            Assert.AreEqual(false, _service.UpdateRoom(1, new RoomDTO() { Id = -1, Name = "B", Devices = new List<IDevice>() }).Result);
        }
    }
}
