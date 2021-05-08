using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClientDataLayer.Interfaces;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ClientDataLayer
{
    public class RoomRepository : INamedRepository<Room>
    {
        private static RoomRepository _instance;
        public static RoomRepository Instance
        {
            get { return _instance ??= new RoomRepository(); }
            private set => _instance = value;
        }

        public async Task<IEnumerable<Room>> Get()
        {
            return await Task.FromResult(DataContext.Instance.Rooms);
        }

        public Room Get(int id)
        {
            return DataContext.Instance.Rooms.Find(room => room.Id == id);
        }

        public async Task<bool> Add(Room item)
        {
            DataContext.Instance.Rooms.Add(item);
            return await Task.FromResult(true);
        }

        public bool Remove(int id)
        {
            return DataContext.Instance.Rooms.RemoveAll(room => room.Id == id) > 0;
        }

        public bool Remove(Room item)
        {
            return DataContext.Instance.Rooms.Remove(item);
        }

        public bool Update(int id, Room item)
        {
            Room found = DataContext.Instance.Rooms.Find(room => room.Id == id);
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
            return DataContext.Instance.Rooms.Find(room => room.Name == name);
        }

        public IEnumerable<Room> GetAll(string name)
        {
            return DataContext.Instance.Rooms.FindAll(room => room.Name == name);
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
            return DataContext.Instance.Rooms.RemoveAll(room => room.Name == name);
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
