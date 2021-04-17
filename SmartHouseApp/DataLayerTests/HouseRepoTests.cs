using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Devices;
using DataLayer.Repositories;
using NuGet.Frameworks;
using NUnit.Framework;

namespace DataLayerTests
{
    class HouseRepoTests
    {
        private DataContext _context;
        private HouseRepository _hRepo;

        [SetUp]
        public void Setup()
        {
            _context = new DataContext();
            _hRepo = new HouseRepository(_context);

            _hRepo.Add(new House() { Id = 0, Name = "House0" });
            _hRepo.Add(new House() { Id = 1, Name = "House1" });
            _hRepo.Add(new House() { Id = 2, Name = "House" });
            _hRepo.Add(new House() { Id = 3, Name = "House" });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(_hRepo.Get(0).Id, 0);
            Assert.AreEqual(_hRepo.Get(1).Name, "House1");
            var all = _hRepo.Get().ToList();
            Assert.AreEqual(all[0].Name, "House0");
            Assert.AreEqual(all[1].Name, "House1");
            Assert.AreEqual(all[2].Name, "House");
            Assert.AreEqual(all[3].Name, "House");
        }

        [Test]
        public void GetAllTest()
        {
            var all = _hRepo.GetAll("House").ToList();
            Assert.AreEqual(all.Count, 2);
            Assert.AreEqual(all[0].Id, 2);
            Assert.AreEqual(all[1].Id, 3);
        }

        [Test]
        public void GetIdTest()
        {
            Assert.AreEqual(_hRepo.GetFirstId("House0"), 0);
            Assert.AreEqual(_hRepo.GetFirstId("House"), 2);
            var all = _hRepo.GetIds("House");
            Assert.AreEqual(all.Length, 2);
            Assert.AreEqual(all[0], 2);
            Assert.AreEqual(all[1], 3);
        }
    }
}
