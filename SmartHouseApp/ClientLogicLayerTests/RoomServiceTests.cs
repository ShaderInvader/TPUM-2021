using System;
using System.Collections.Generic;
using System.Linq;
using ClientDataLayer;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.Services;
using Moq;
using NUnit.Framework;

namespace LogicLayerTests
{
    class RoomServiceTests
    {
        private Mock<INamedRepository<Room>> _RoomRepoMock;
        private RoomService hService;

        [SetUp]
        public void Setup()
        {
            _RoomRepoMock = new Mock<INamedRepository<Room>>();

            // Get by id
            _RoomRepoMock.Setup(x => x.Get(0)).Returns(new Room() { Id = 0, Name = "Loft" });
            _RoomRepoMock.Setup(x => x.Get(1)).Returns(new Room() { Id = 1, Name = "Mieszkanie" });
            _RoomRepoMock.Setup(x => x.Get(2)).Returns(new Room() { Id = 2, Name = "Dom" });
            _RoomRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // Get everything
            _RoomRepoMock.Setup(x => x.Get()).Returns(new List<Room>()
            {
                new Room() {Id = 10, Name = "A"},
                new Room() {Id = 11, Name = "B"},
                new Room() {Id = 12, Name = "C"},
                new Room() {Id = 13, Name = "D"},
                new Room() {Id = 14, Name = "E"}
            });

            // Get all
            _RoomRepoMock.Setup(x => x.GetAll("Domek")).Returns(new List<Room>()
            {
                new Room() {Id = 100, Name = "Domek"},
                new Room() {Id = 101, Name = "Domek"},
                new Room() {Id = 102, Name = "Domek"},
            });

            hService = new RoomService(_RoomRepoMock.Object);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(hService.GetRoom(0).Name, "Loft");
            Assert.AreEqual(hService.GetRoom(1).Id, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => hService.GetRoom(-1));
        }

        [Test]
        public void TestGetAll()
        {
            var Rooms = hService.GetRooms().ToList();
            Assert.AreEqual(Rooms.Count, 5);
            Assert.AreEqual(Rooms[0].Id, 10);
            Assert.AreEqual(Rooms[1].Name, "B");
        }
    }
}
