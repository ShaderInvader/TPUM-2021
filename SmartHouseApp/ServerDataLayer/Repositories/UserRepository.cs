using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ServerDataLayer
{
    public class UserRepository : INamedRepository<User>
    {
        private readonly DataContext _dataContext;

        public UserRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region INamedRepository<User>

        public void Add(User item)
        {
            _dataContext.Users.Add(item);
        }

        public User Get(string name)
        {
            return _dataContext.Users.Find(user => user.Name == name);
        }

        public IEnumerable<User> Get()
        {
            return _dataContext.Users;
        }

        public User Get(int id)
        {
            return _dataContext.Users.Find(user => user.Id == id);
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
            bool returnValue = false;
            if (found != null)
            {
                found.Email = item.Email;
                found.Name = item.Name;
                found.FirstName = item.FirstName;
                found.LastName = item.LastName;
                found.Location = item.Location;
                found.Email = item.Email;
                found.Password = item.Password;

                returnValue = true;
            }
            return returnValue;
        }

        public int UpdateAll(string name, User item)
        {
            List<User> found = _dataContext.Users.FindAll(user => user.Name == name);
            foreach (var u in found)
            {
                u.Email = item.Email;
                u.Name = item.Name;
                u.FirstName = item.FirstName;
                u.LastName = item.LastName;
                u.Location = item.Location;
            }
            return found.Count;
        }

        public bool UpdateFirst(string name, User item)
        {
            User found = _dataContext.Users.Find(user => user.Name == name);
            bool returnValue = false;
            if (found != null)
            {
                found.Email = item.Email;
                found.Name = item.Name;
                found.FirstName = item.FirstName;
                found.LastName = item.LastName;
                found.Location = item.Location;

                returnValue = true;
            }
            return returnValue;
        } 
        
        #endregion
        
    }
}
