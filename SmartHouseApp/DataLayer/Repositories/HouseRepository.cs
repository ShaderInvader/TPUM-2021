using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class HouseRepository : INamedRepository<House>
    {
        private readonly DataContext _dataContext;

        public HouseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<House> Get()
        {
            return _dataContext.Houses;
        }

        public House Get(int id)
        {
            return _dataContext.Houses.Find(house => house.Id == id);
        }

        public void Add(House item)
        {
            _dataContext.Houses.Add(item);
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
            if (found != null)
            {
                found.Name = item.Name;
                found.Rooms = new List<Room>(item.Rooms);
                return true;
            }

            return false;
        }

        public House Get(string name)
        {
            return _dataContext.Houses.Find(house => house.Name == name);
        }

        public IEnumerable<House> GetAll(string name)
        {
            return _dataContext.Houses.FindAll(house => house.Name == name);
        }

        public int GetFirstId(string name)
        {
            House found = Get(name);
            if (found != null)
            {
                return found.Id;
            }

            return -1;
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

        public bool UpdateFirst(string name, House item)
        {
            House found = Get(name);
            if (found != null)
            {
                found.Name = item.Name;
                found.Rooms = new List<Room>(item.Rooms);
                return true;
            }

            return false;
        }

        public int UpdateAll(string name, House item)
        {
            List<House> found = (List<House>)GetAll(name);
            foreach (var t in found)
            {
                t.Name = item.Name;
                t.Rooms = new List<Room>(item.Rooms);
            }
            return found.Count;
        }
    }
}
