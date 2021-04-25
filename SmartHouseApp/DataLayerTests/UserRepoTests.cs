using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using NUnit.Framework;

namespace DataLayerTests
{
    class UserRepoTests
    {
        private DataContext _context;
        private UserRepository _uRepo;

        [SetUp]
        public void Setup()
        {
            _context = new DataContext();
            _uRepo = new UserRepository(_context);

            _uRepo.Add(new User() { Name = "amazurek", FirstName = "Adam", LastName = "Mazurek", Email = "amazurek@outlook.com", Id = 0 });
            _uRepo.Add(new User() { Name = "amazurek", FirstName = "Adrianna", LastName = "Mazurek", Email = "amazurek@gmail.com", Id = 1});
            _uRepo.Add(new User() { Email = "jan.kowalski@gmail.com", FirstName = "Jan", Id = 2, LastName = "Kowalski", Name = "jkowalski" });
            _uRepo.Add(new User() { Email = "karol.nowak@gmail.com", FirstName = "Karol", Id = 3, LastName = "Nowak", Name = "knowak" });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(_uRepo.Get(0).Id, 0);
            Assert.AreEqual(_uRepo.Get(1).Name, "amazurek");
            var all = _uRepo.Get().ToList();
            Assert.AreEqual(all[0].Name, "amazurek");
            Assert.AreEqual(all[1].Name, "amazurek");
            Assert.AreEqual(all[2].Name, "jkowalski");
            Assert.AreEqual(all[3].Name, "knowak");
        }

        [Test]
        public void GetAllTest()
        {
            var all = _uRepo.GetAll("amazurek").ToList();
            Assert.AreEqual(all.Count, 2);
            Assert.AreEqual(all[0].Id, 0);
            Assert.AreEqual(all[1].Id, 1);
        }

        [Test]
        public void GetIdTest()
        {
            Assert.AreEqual(_uRepo.GetFirstId("jkowalski"), 2);
            Assert.AreEqual(_uRepo.GetFirstId("amazurek"), 0);
            var all = _uRepo.GetIds("amazurek");
            Assert.AreEqual(all.Length, 2);
            Assert.AreEqual(all[0], 0);
            Assert.AreEqual(all[1], 1);
        }
    }
}
