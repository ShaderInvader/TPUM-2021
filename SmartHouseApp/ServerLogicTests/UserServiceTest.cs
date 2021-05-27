using NUnit.Framework;
using Moq;
using ServerDataLayer;
using System;
using System.Collections.Generic;
using ServerLogicLayer;

namespace ServerLogicTests
{
    class UserServiceTest
    {
        private Mock<INamedRepository<User>> _mockRepo;
        private UserService _service;

        private static Tuple<double, double> coords = new Tuple<double, double>(1, 1);
        private User aUser0 = new User() { Name = "amazurek", FirstName = "Adam", LastName = "Mazurek", Email = "amazurek@outlook.com", Id = 2, Coordinates = new Location() { Coordinates = coords } };
        private User aUser1 = new User() { Name = "amazurek", FirstName = "Adrianna", LastName = "Mazurek", Email = "amazurek@gmail.com", Id = 3, Coordinates = new Location() { Coordinates = coords } };
        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<INamedRepository<User>>();

            // ===== Get by id setup =====
            _mockRepo.Setup(x => x.Get(0)).Returns(new User() { Email = "jan.kowalski@gmail.com", FirstName = "Jan", Id = 0, LastName = "Kowalski", Name = "jkowalski", Coordinates = new Location() { Coordinates = coords } });
            _mockRepo.Setup(x => x.Get(1)).Returns(new User() { Email = "karol.nowak@gmail.com", FirstName = "Karol", Id = 1, LastName = "Nowak", Name = "knowak", Coordinates = new Location() {Coordinates = coords } });
            _mockRepo.Setup(x => x.Get(It.Is<int>(i => i < 0))).Throws<ArgumentOutOfRangeException>();

            // ===== Get everything setup =====
            _mockRepo.Setup(x => x.Get()).Returns(new List<User>()
            {
                new User() { Name = "sjanusz", FirstName = "Sylwia", LastName = "Janusz", Email = "sjanusz@outlook.com", Id = 0, Coordinates = new Location() { Coordinates = coords }},
                new User() { Name = "ggóra", FirstName = "Gabiriela", LastName = "Góra", Email = "ggora@gmail.com", Id = 1, Coordinates = new Location() { Coordinates = coords } }
            });

            //Add mock
            _mockRepo.Setup(x => x.Add(aUser0)).Returns(false);
            _mockRepo.Setup(x => x.Add(aUser1)).Returns(false);

            //Remove mock
            _mockRepo.Setup(x => x.Remove(1)).Returns(true);
            _mockRepo.Setup(x => x.Remove(3)).Returns(false);

            //Update test
            _mockRepo.Setup(x => x.Update(1, aUser1)).Returns(false);

            _service = new UserService(_mockRepo.Object);
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("jkowalski", _service.GetUser(0).Result.Name);
            Assert.AreEqual("Nowak", _service.GetUser(1).Result.LastName);
            Assert.AreEqual(2, ((List<UserDTO>)_service.GetUsers().Result).Count);
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(false, _service.AddUser(Mapper.Map(aUser0)).Result);
            Assert.AreEqual(false, _service.AddUser(Mapper.Map(aUser1)).Result);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(true, _service.RemoveUser(1).Result);
            Assert.AreEqual(false, _service.RemoveUser(3).Result);
        }

        [Test]
        public void UpdateTest()
        {
            Assert.AreEqual(false, _service.UpdateUser(1, Mapper.Map(aUser1)).Result);
        }
    }
}
