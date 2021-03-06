using System.Collections.Generic;

namespace ServerDataLayer
{
    public class UserRepository : INamedRepository<User>
    {
        private readonly DataContext _dataContext;
        private readonly object _userLock = new object();

        public UserRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region INamedRepository<User>

        public bool Add(User item)
        {
            _dataContext.Users.Add(item);
            return true;
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

        public int Remove(string name)
        {
            return _dataContext.Users.RemoveAll(user => user.Name == name);
        }

        public bool Remove(int id)
        {
            return _dataContext.Users.RemoveAll(user => user.Id == id) > 0;
        }

        public bool Update(int id, User item)
        {
            User found = _dataContext.Users.Find(user => user.Id == id);
            bool returnValue = false;
            if (found != null)
            {
                lock(_userLock)
                {
                    found.Email = item.Email;
                    found.Name = item.Name;
                    found.FirstName = item.FirstName;
                    found.LastName = item.LastName;
                    found.Coordinates = item.Coordinates;
                    found.Email = item.Email;
                    found.Password = item.Password;
                }

                returnValue = true;
            }
            return returnValue;
        }
        
        #endregion
        
    }
}
