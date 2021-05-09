using System.Linq;
using ClientDataLayer;
using ModelCommon;
using NUnit.Framework;

namespace DataLayerTests
{
    class RoomRepoTests
    {
        private RoomRepository _rRepo;

        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Rooms.Clear();
            DataContext.Instance.Rooms.Add(new Room() { Id = 0, Name = "Room0"});
            DataContext.Instance.Rooms.Add(new Room() { Id = 1, Name = "Room1"});
            DataContext.Instance.Rooms.Add(new Room() { Id = 2, Name = "Room2"});
            DataContext.Instance.Rooms.Add(new Room() { Id = 3, Name = "Room2"});
            _rRepo = new RoomRepository();
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(0, _rRepo.Get(0).Id);
            Assert.AreEqual("Room1", _rRepo.Get(1).Name);
            var all = _rRepo.Get().ToList();
            Assert.AreEqual("Room0", all[0].Name);
            Assert.AreEqual("Room1", all[1].Name);
            Assert.AreEqual("Room2", all[2].Name);
            Assert.AreEqual("Room2", all[3].Name);
        }

        [Test]
        public void GetAllTest()
        {
            var all = _rRepo.GetAll("Room2").ToList();
            Assert.AreEqual(2, all.Count);
            Assert.AreEqual(2, all[0].Id);
            Assert.AreEqual(3, all[1].Id);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(1, _rRepo.Remove("Room0"));
            Assert.AreEqual(true, _rRepo.Remove(1));
            var all = _rRepo.Get().ToList();
            Assert.AreEqual(2, all.Count);
            Assert.AreEqual(2, all[0].Id);
            Assert.AreEqual(3, all[1].Id);
        }
    }
}
