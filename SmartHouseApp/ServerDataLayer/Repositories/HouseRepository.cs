using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;
using ModelCommon;

namespace ServerDataLayer
{
    public class HouseRepository : INamedRepository<House>
    {
        private readonly DataContext _dataContext;
        private readonly object _houseLock = new object();

        public HouseRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region INamedRepository<House>

        public void Add(House item)
        {
            _dataContext.Houses.Add(item);
        }

        public House Get(string name)
        {
            return _dataContext.Houses.Find(house => house.Name == name);
        }

        public IEnumerable<House> Get()
        {
            return _dataContext.Houses;
        }

        public House Get(int id)
        {
            return _dataContext.Houses.Find(house => house.Id == id);
        }

        public IEnumerable<House> GetAll(string name)
        {
            return _dataContext.Houses.FindAll(house => house.Name == name);
        }

        public int GetFirstId(string name)
        {
            House found = Get(name);
            int foundId = -1;
            if (found != null)
            {
                foundId = found.Id;
            }

            return foundId;
        }

        public int[] GetIds(string name)
        {
            List<House> found = (List<House>)GetAll(name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return _dataContext.Houses.RemoveAll(house => house.Name == name);
        }

        public int Remove(int id)
        {
            return _dataContext.Houses.RemoveAll(house => house.Id == id);
        }

        public bool Remove(House item)
        {
            return _dataContext.Houses.Remove(item);
        }

        public bool Update(int id, House item)
        {
            House found = _dataContext.Houses.Find(house => house.Id == id);
            bool returnValue = false;
            if (found != null)
            {
                lock(_houseLock)
                {
                    found.Name = item.Name;
                    found.Devices = new List<IDevice>(item.Devices);
                    found.Location = item.Location;
                }
                returnValue = true;
            }

            return returnValue;
        }

        public int UpdateAll(string name, House item)
        {
            List<House> found = (List<House>)GetAll(name);
            foreach (var h in found)
            {
                lock (_houseLock)
                {
                    h.Name = item.Name;
                    h.Devices = new List<IDevice>(item.Devices);
                    h.Location = item.Location;
                }
            }
            return found.Count;
        }

        public bool UpdateFirst(string name, House item)
        {
            House found = Get(name);
            bool returnValue = false;
            if (found != null)
            {
                lock (_houseLock)
                {
                    found.Name = item.Name;
                    found.Devices = new List<IDevice>(item.Devices);
                    found.Location = item.Location;
                }
                returnValue = true;
            }

            return returnValue;
        }
        #endregion
    }
}
