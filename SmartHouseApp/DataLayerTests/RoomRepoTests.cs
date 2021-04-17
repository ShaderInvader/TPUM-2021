using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Repositories;
using NUnit.Framework;

namespace DataLayerTests
{
    class RoomRepoTests
    {
        private DataContext _context;
        private RoomRepository _rRepo;

        [SetUp]
        public void Setup()
        {
            _context = new DataContext();
            _rRepo = new RoomRepository(_context);

            _rRepo.Add(new Room() { Id = 0, Name = "Room0", Description = "Room upstairs"});
            _rRepo.Add(new Room() { Id = 1, Name = "Room1", Description = "Room downstairs" });
            _rRepo.Add(new Room() { Id = 2, Name = "Room", Description = "" });
            _rRepo.Add(new Room() { Id = 3, Name = "Room", Description = "" });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(_rRepo.Get(0).Id, 0);
            Assert.AreEqual(_rRepo.Get(1).Name, "Room1");
            var all = _rRepo.Get().ToList();
            Assert.AreEqual(all[0].Name, "Room0");
            Assert.AreEqual(all[1].Name, "Room1");
            Assert.AreEqual(all[2].Name, "Room");
            Assert.AreEqual(all[3].Name, "Room");
        }

        [Test]
        public void GetAllTest()
        {
            var all = _rRepo.GetAll("Room").ToList();
            Assert.AreEqual(all.Count, 2);
            Assert.AreEqual(all[0].Id, 2);
            Assert.AreEqual(all[1].Id, 3);
        }

        [Test]
        public void GetIdTest()
        {
            Assert.AreEqual(_rRepo.GetFirstId("Room0"), 0);
            Assert.AreEqual(_rRepo.GetFirstId("Room"), 2);
            var all = _rRepo.GetIds("Room");
            Assert.AreEqual(all.Length, 2);
            Assert.AreEqual(all[0], 2);
            Assert.AreEqual(all[1], 3);
        }
    }
}
