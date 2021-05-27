using System.Linq;
using ClientDataLayer;
using NUnit.Framework;

namespace DataLayerTests
{
    class UserRepoTests
    {
        private UserRepository _uRepo;

        [SetUp]
        public void Setup()
        {
            DataContext.Instance.Users.Clear();
            DataContext.Instance.Users.Add(new User() { Name = "amazurek", FirstName = "Adam", LastName = "Mazurek", Email = "amazurek@outlook.com", Id = 0 });
            DataContext.Instance.Users.Add(new User() { Name = "amazurek", FirstName = "Adrianna", LastName = "Mazurek", Email = "amazurek@gmail.com", Id = 1 });
            DataContext.Instance.Users.Add(new User() { Email = "jan.kowalski@gmail.com", FirstName = "Jan", Id = 2, LastName = "Kowalski", Name = "jkowalski" });
            DataContext.Instance.Users.Add(new User() { Email = "karol.nowak@gmail.com", FirstName = "Karol", Id = 3, LastName = "Nowak", Name = "knowak" });
            _uRepo = new UserRepository();
        }

        [Test]
        public void GetTest()
        {
            Assert.AreEqual(0, _uRepo.Get(0).Id);
            Assert.AreEqual("amazurek", _uRepo.Get(1).Name);
            var all = _uRepo.Get().ToList();
            Assert.AreEqual("amazurek", all[0].Name);          
            Assert.AreEqual("amazurek", all[1].Name);          
            Assert.AreEqual("jkowalski", all[2].Name);         
            Assert.AreEqual("knowak", all[3].Name); 
        }

        [Test]
        public void GetAllTest()
        {
            var all = _uRepo.GetAll("amazurek").ToList();
            Assert.AreEqual(2, all.Count);
            Assert.AreEqual(0, all[0].Id);
            Assert.AreEqual(1, all[1].Id);
        }

        [Test]
        public void RemoveTest()
        {
            Assert.AreEqual(2, _uRepo.Remove("amazurek"));
            Assert.AreEqual(true, _uRepo.Remove(2));
            var all = _uRepo.Get().ToList();
            Assert.AreEqual(1, all.Count);
            Assert.AreEqual(3, all[0].Id);
        }
    }
}
