using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using LogicLayer;
using Moq;
using NUnit.Framework;

namespace LogicLayerTests
{
    public class UserServiceTests
    {
        private Mock<INamedRepository<User>> _userRepoMock;
        private UserService uService;

        [SetUp]
        public void Setup()
        {
            _userRepoMock = new Mock<INamedRepository<User>>();

            // ===== Get by id setup =====
            _userRepoMock.Setup(x => x.Get(0)).Returns(new User() { Email = "jan.kowalski@gmail.com", FirstName = "Jan", Id = 0, LastName = "Kowalski", Name = "jkowalski" });
            _userRepoMock.Setup(x => x.Get(1)).Returns(new User() { Email = "karol.nowak@gmail.com", FirstName = "Karol", Id = 1, LastName = "Nowak", Name = "knowak" });
            _userRepoMock.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();
            _userRepoMock.Setup(x => x.Get(It.Is<int>(i => i > 1))).Throws<ArgumentOutOfRangeException>();

            // ===== Get all setup =====
            User aUser0 = new User() {Name = "amazurek", FirstName = "Adam", LastName = "Mazurek", Email = "amazurek@outlook.com", Id = 2};
            User aUser1 = new User() {Name = "amazurek", FirstName = "Adrianna", LastName = "Mazurek", Email = "amazurek@gmail.com", Id = 3};

            _userRepoMock.Setup(x => x.GetAll("amazurek")).Returns(new List<User>()
            {
                aUser0, aUser1
            });

            // ===== Get everything setup =====
            _userRepoMock.Setup(x => x.Get()).Returns(new List<User>()
            {
                new User() {Name = "sjanusz", FirstName = "Sylwia", LastName = "Janusz", Email = "sjanusz@outlook.com", Id = 0},
                new User() { Name = "ggóra", FirstName = "Gabiriela", LastName = "Góra", Email = "ggora@gmail.com", Id = 1 }
            });

            uService = new UserService(_userRepoMock.Object);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(uService.GetUser(0).Name, "jkowalski");
            Assert.AreEqual(uService.GetUser(1).Id, Mapper.Map(_userRepoMock.Object.Get(1)).Id);
            Assert.Throws<ArgumentOutOfRangeException>(() => uService.GetUser(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => uService.GetUser(999));
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(uService.GetUsers().ToList()[0].Name, _userRepoMock.Object.Get().ToList()[0].Name);
        }

        [Test]
        public void TestGetByName()
        {
            Assert.AreEqual(uService.GetUsersByName("amazurek").ToList()[0].Id, _userRepoMock.Object.GetAll("amazurek").ToList()[0].Id);
        }
    }
}