using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ModelCommon;

namespace ClientDataLayer
{
    public class UserRepository : INamedRepository<User>
    {
        private static UserRepository _instance;
        public static UserRepository Instance
        {
            get { return _instance ??= new UserRepository(); }
            private set => _instance = value;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return DataContext.Instance.Users;
        }

        public User Get(int id)
        {
            return DataContext.Instance.Users.Find(user => user.Id == id);
        }

        public bool Add(User item)
        {
            DataContext.Instance.Users.Add(item);
            return true;
        }

        public bool Remove(int id)
        {
            return DataContext.Instance.Users.RemoveAll(user => user.Id == id) > 0;
        }

        public bool Remove(User item)
        {
            return DataContext.Instance.Users.Remove(item);
        }

        public bool Update(int id, User item)
        {
            User found = DataContext.Instance.Users.Find(user => user.Id == id);
            if (found != null)
            {
                found.Email = item.Email;
                found.Name = item.Name;
                found.FirstName = item.FirstName;
                found.LastName = item.LastName;
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Get(string name)
        {
            return DataContext.Instance.Users.Find(user => user.Name == name);
        }

        public IEnumerable<User> GetAll(string name)
        {
            return DataContext.Instance.Users.FindAll(user => user.Name == name);
        }

        public int[] GetIds(string name)
        {
            List<User> found = DataContext.Instance.Users.FindAll(user => user.Name == name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return DataContext.Instance.Users.RemoveAll(user => user.Name == name);
        }

        public int UpdateAll(string name, User item)
        {
            List<User> found = DataContext.Instance.Users.FindAll(user => user.Name == name);
            foreach (var t in found)
            {
                t.Email = item.Email;
                t.Name = item.Name;
                t.FirstName = item.FirstName;
                t.LastName = item.LastName;
            }
            return found.Count;
        }
    }
}
