using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UserRepository : INamedRepository<User>
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<User> Get()
        {
            return _dataContext.Users;
        }

        public User Get(int id)
        {
            return _dataContext.Users.Find(user => user.Id == id);
        }

        public void Add(User item)
        {
            _dataContext.Users.Add(item);
        }

        public int Remove(int id)
        {
            return _dataContext.Users.RemoveAll(user => user.Id == id);
        }

        public bool Remove(User item)
        {
            return _dataContext.Users.Remove(item);
        }

        public bool Update(int id, User item)
        {
            User found = _dataContext.Users.Find(user => user.Id == id);
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
            return _dataContext.Users.Find(user => user.Name == name);
        }

        public IEnumerable<User> GetAll(string name)
        {
            return _dataContext.Users.FindAll(user => user.Name == name);
        }

        public int GetFirstId(string name)
        {
            User found = _dataContext.Users.Find(user => user.Name == name);
            if (found != null)
            {
                return found.Id;
            }
            else
            {
                return -1;
            }
        }

        public int[] GetIds(string name)
        {
            List<User> found = _dataContext.Users.FindAll(user => user.Name == name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return _dataContext.Users.RemoveAll(user => user.Name == name);
        }

        public bool UpdateFirst(string name, User item)
        {
            User found = _dataContext.Users.Find(user => user.Name == name);
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

        public int UpdateAll(string name, User item)
        {
            List<User> found = _dataContext.Users.FindAll(user => user.Name == name);
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
