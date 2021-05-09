using NUnit.Framework;
using ServerDataLayer;
using ModelCommon;
using System.Collections.Generic;

namespace ServerDataTests
{
    class UserRepoTest
    {
        private UserRepository _userRepo;
        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Users.Clear();
            _userRepo = new UserRepository();
            _userRepo.Add(new User() { Id = 0, Name = "jKowal", FirstName = "Jan", LastName = "Kowalski", Email = "jKowal@gmail.com", Password = "12345678" });
            _userRepo.Add(new User() { Id = 1, Name = "aNova", FirstName = "Anna", LastName = "Nowak", Email = "aNova@gmail.com", Password = "admin" });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual("jKowal", _userRepo.Get(0).Name);
            Assert.AreEqual(1, _userRepo.Get("aNova").Id);
            Assert.AreEqual("Kowalski", _userRepo.Get("jKowal").LastName);
            var allUsers = (List<User>)_userRepo.Get();
            Assert.AreEqual(2, allUsers.Count);
        }

        [Test]
        public void AddTest()
        {
            Assert.AreEqual(true, _userRepo.Add(new User { Id = 2, Name = "bKasz", FirstName = "Błażej", LastName = "Kaszyński", Email = "bKasz@gmail.com", Password="kaszanka"}));
            Assert.AreEqual("bKasz@gmail.com", _userRepo.Get(2).Email);
            var allUsers = (List<User>)_userRepo.Get();
            Assert.AreEqual(3, allUsers.Count);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(false, _userRepo.Remove(5));
            Assert.AreEqual(true, _userRepo.Remove(0));
            var allUsers = (List<User>)_userRepo.Get();
            Assert.AreEqual(1, allUsers.Count);
            Assert.AreEqual(1, allUsers[0].Id);
        }

        [Test]
        public void RemoveByNameTest()
        {
            Assert.AreEqual(1, _userRepo.Remove("aNova"));
            var allDevices = (List<User>)_userRepo.Get();
            Assert.AreEqual(1, allDevices.Count);
            Assert.AreEqual(0, allDevices[0].Id);
        }

        [Test]
        public void UpdateTest()
        {
            var u = _userRepo.Get(0);
            u.Email = "jKowalski@gmail.com";
            Assert.AreEqual(true, _userRepo.Update(0, u));
            Assert.AreEqual("jKowalski@gmail.com", _userRepo.Get(0).Email);
        }

    }
}
