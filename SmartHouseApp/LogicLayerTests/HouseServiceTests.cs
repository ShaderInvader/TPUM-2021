//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DataLayer;
//using LogicLayer;
//using Moq;
//using NUnit.Framework;

//namespace LogicLayerTests
//{
//    class HouseServiceTests
//    {
//        private Mock<INamedRepository<House>> _houseRepoMock;
//        private HouseService hService;

//        [SetUp]
//        public void Setup()
//        {
//            _houseRepoMock = new Mock<INamedRepository<House>>();

//            // Get by id
//            _houseRepoMock.Setup(x => x.Get(0)).Returns(new House() { Id = 0, Name = "Loft" });
//            _houseRepoMock.Setup(x => x.Get(1)).Returns(new House() { Id = 1, Name = "Mieszkanie" });
//            _houseRepoMock.Setup(x => x.Get(2)).Returns(new House() { Id = 2, Name = "Dom" });
//            _houseRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

//            // Get everything
//            _houseRepoMock.Setup(x => x.Get()).Returns(new List<House>()
//            {
//                new House() {Id = 10, Name = "A"},
//                new House() {Id = 11, Name = "B"},
//                new House() {Id = 12, Name = "C"},
//                new House() {Id = 13, Name = "D"},
//                new House() {Id = 14, Name = "E"}
//            });

//            // Get all
//            _houseRepoMock.Setup(x => x.GetAll("Domek")).Returns(new List<House>()
//            {
//                new House() {Id = 100, Name = "Domek"},
//                new House() {Id = 101, Name = "Domek"},
//                new House() {Id = 102, Name = "Domek"},
//            });

//            hService = new HouseService(_houseRepoMock.Object);
//        }

//        [Test]
//        public void TestGet()
//        {
//            Assert.AreEqual(hService.GetHouse(0).Name, "Loft");
//            Assert.AreEqual(hService.GetHouse(1).Id, 1);
//            Assert.Throws<ArgumentOutOfRangeException>(() => hService.GetHouse(-1));
//        }

//        [Test]
//        public void TestGetAll()
//        {
//            var houses = hService.GetHouses().ToList();
//            Assert.AreEqual(houses.Count, 5);
//            Assert.AreEqual(houses[0].Id, 10);
//            Assert.AreEqual(houses[1].Name, "B");
//        }

//        [Test]
//        public void TestGetByName()
//        {
//            var houses = hService.GetHousesByName("Domek").ToList();
//            Assert.AreEqual(houses.Count, 3);
//            Assert.AreEqual(houses[0].Name, "Domek");
//            Assert.AreEqual(houses[1].Name, "Domek");
//            Assert.AreEqual(houses[2].Name, "Domek");
//        }
//    }
//}
