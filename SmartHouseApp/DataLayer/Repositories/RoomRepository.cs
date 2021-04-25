using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class RoomRepository : INamedRepository<Room>
    {
        private readonly DataContext _dataContext;

        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Room> Get()
        {
            return _dataContext.Rooms;
        }

        public Room Get(int id)
        {
            return _dataContext.Rooms.Find(room => room.Id == id);
        }

        public void Add(Room item)
        {
            _dataContext.Rooms.Add(item);
        }

        public int Remove(int id)
        {
            return _dataContext.Rooms.RemoveAll(room => room.Id == id);
        }

        public bool Remove(Room item)
        {
            return _dataContext.Rooms.Remove(item);
        }

        public bool Update(int id, Room item)
        {
            Room found = _dataContext.Rooms.Find(room => room.Id == id);
            if (found != null)
            {
                found.Name = item.Name;
                found.Description = item.Description;
                found.Devices = new List<IDevice>(item.Devices);
                return true;
            }

            return false;
        }

        public Room Get(string name)
        {
            return _dataContext.Rooms.Find(room => room.Name == name);
        }

        public IEnumerable<Room> GetAll(string name)
        {
            return _dataContext.Rooms.FindAll(room => room.Name == name);
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
            List<Room> found = (List<Room>) GetAll(name);
            int[] ids = new int[found.Count];
            for (int i = 0; i < found.Count; i++)
            {
                ids[i] = found[i].Id;
            }

            return ids;
        }

        public int Remove(string name)
        {
            return _dataContext.Rooms.RemoveAll(room => room.Name == name);
        }

        public bool UpdateFirst(string name, Room item)
        {
            Room found = Get(name);
            if (found != null)
            {
                found.Name = item.Name;
                found.Description = item.Description;
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
                t.Description = item.Description;
                t.Devices = new List<IDevice>(item.Devices);
            }
            return found.Count;
        }
    }
}
