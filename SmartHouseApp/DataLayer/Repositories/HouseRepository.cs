using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon;
using ModelCommon.Interfaces;

namespace DataLayer
{
    public class HouseRepository : INamedRepository<Room>
    {
        private readonly DataContext _dataContext;

        public HouseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Room> Get()
        {
            return _dataContext.Houses;
        }

        public Room Get(int id)
        {
            return _dataContext.Houses.Find(house => house.Id == id);
        }

        public void Add(Room item)
        {
            _dataContext.Houses.Add(item);
        }

        public int Remove(int id)
        {
            return _dataContext.Houses.RemoveAll(house => house.Id == id);
        }

        public bool Remove(Room item)
        {
            return _dataContext.Houses.Remove(item);
        }

        public bool Update(int id, Room item)
        {
            Room found = _dataContext.Houses.Find(house => house.Id == id);
            if (found != null)
            {
                found.Name = item.Name;
                found.Devices = new List<IDevice>(item.Devices);
                return true;
            }

            return false;
        }

        public Room Get(string name)
        {
            return _dataContext.Houses.Find(house => house.Name == name);
        }

        public IEnumerable<Room> GetAll(string name)
        {
            return _dataContext.Houses.FindAll(house => house.Name == name);
        }

        public int GetFirstId(string name)
        {
            Room found = Get(name);
            if (found != null)
            {
                return found.Id;
            }

            return -1;
        }

        public int[] GetIds(string name)
        {
            List<Room> found = (List<Room>)GetAll(name);
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

        public bool UpdateFirst(string name, Room item)
        {
            Room found = Get(name);
            if (found != null)
            {
                found.Name = item.Name;
                found.Devices = new List<IDevice>(item.Devices);
                return true;
            }

            return false;
        }

        public int UpdateAll(string name, Room item)
        {
            List<Room> found = (List<Room>)GetAll(name);
            foreach (var t in found)
            {
                t.Name = item.Name;
                t.Devices = new List<IDevice>(item.Devices);
            }
            return found.Count;
        }
    }
}
