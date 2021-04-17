using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Interfaces;
using LogicLayer;
using LogicLayer.Services;
using Moq;
using NUnit.Framework;

namespace LogicLayerTests
{
    class RoomServiceTests
    {
        private Mock<INamedRepository<Room>> _roomRepoMock;
        private RoomService rService;

        [SetUp]
        public void Setup()
        {
            _roomRepoMock = new Mock<INamedRepository<Room>>();

            // ===== Get by ID setup =====
            _roomRepoMock.Setup(x => x.Get(0))
                .Returns(new Room() {Id = 0, Name = "LivingRoom", Description = "room"});
            _roomRepoMock.Setup(x => x.Get(1))
                .Returns(new Room() { Id = 1, Name = "Bathroom", Description = "room" });
            _roomRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // ===== Get all =====
            _roomRepoMock.Setup(x => x.GetAll("Bedroom"))
                .Returns(new List<Room>()
                {
                    new Room() {Id = 10, Name = "Bedroom", Description = "Room with a bed"},
                    new Room() {Id = 11, Name = "Bedroom", Description = "Room with two beds"}
                });

            // ===== Get everything =====
            _roomRepoMock.Setup(x => x.Get())
                .Returns(new List<Room>()
                {
                    new Room() {Id = 100, Name = "A", Description = ""},
                    new Room() {Id = 101, Name = "B", Description = ""},
                    new Room() {Id = 102, Name = "C", Description = ""},
                    new Room() {Id = 103, Name = "D", Description = ""},
                    new Room() {Id = 104, Name = "D", Description = ""},
                });

            rService = new RoomService(_roomRepoMock.Object);
        }

        [Test]
        public void TestGetRoom()
        {
            Assert.AreEqual(rService.GetRoom(0).Name, "LivingRoom");
            Assert.AreEqual(rService.GetRoom(1).Id, Mapper.Map(_roomRepoMock.Object.Get(1)).Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => rService.GetRoom(-1));
        }

        [Test]
        public void TestGetRooms()
        {
            var rooms = rService.GetRooms().ToList();
            Assert.AreEqual(rooms.Count, 5);
            Assert.AreEqual(rooms[0].Name, "A");
            Assert.AreEqual(rooms[0].Name, _roomRepoMock.Object.Get().ToList()[0].Name);
        }

        [Test]
        public void TestGetByName()
        {
            var rooms = rService.GetRoomsByName("Bedroom").ToList();
            Assert.AreEqual(rooms.Count, 2);
            Assert.AreEqual(rooms[0].Name, "Bedroom");
            Assert.AreEqual(rooms[1].Name, "Bedroom");
        }
    }
}
