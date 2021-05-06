using System.Linq;
using DataLayer;
using NUnit.Framework;

namespace DataLayerTests
{
    public class DeviceRepoTests
    {
        private DataContext _context;
        private DeviceRepository _dRepo;

        [SetUp]
        public void Setup()
        {
            _context = new DataContext();
            _dRepo = new DeviceRepository(_context);

            _dRepo.Add(new LightBulb() {Enabled = false, Id = 0, Name = "bulb0"});
            _dRepo.Add(new MotionDetector() { Enabled = false, Id = 1, Name = "detector" });
            _dRepo.Add(new MotionDetector() { Enabled = false, Id = 2, Name = "detector" });
            _dRepo.Add(new WallSocket() { Enabled = true, Id = 3, Name = "socket0" });
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(_dRepo.Get(0).Id, 0);
            Assert.AreEqual(_dRepo.Get("detector").Id, 1);
            Assert.AreEqual(_dRepo.Get(3).Enabled, true);
            var all = _dRepo.Get().ToList();
            Assert.AreEqual(all[0].Name, "bulb0");
            Assert.AreEqual(all[1].Name, "detector");
            Assert.AreEqual(all[2].Name, "detector");
            Assert.AreEqual(all[3].Name, "socket0");
        }

        [Test]
        public void GetAllTest()
        {
            var all = _dRepo.GetAll("detector").ToList();
            Assert.AreEqual(all.Count, 2);
            Assert.AreEqual(all[0].Id, 1);
            Assert.AreEqual(all[1].Id, 2);
        }

        [Test]
        public void GetIdTest()
        {
            Assert.AreEqual(_dRepo.GetFirstId("bulb0"), 0);
            Assert.AreEqual(_dRepo.GetFirstId("detector"), 1);
            var all = _dRepo.GetIds("detector");
            Assert.AreEqual(all.Length, 2);
            Assert.AreEqual(all[0], 1);
            Assert.AreEqual(all[1], 2);
        }
    }
}