using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;
using ModelCommon;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _dataContext;
        private readonly object _houseLock = new object();

        public RoomRepository()
        {
            _dataContext = DataContext.Instance;
        }

        #region IRoomRepository
        public bool AddDeviceToRoom(int id, IDevice device)
        {
            bool returnValue = false;
            Room r = _dataContext.Rooms.Find(room => room.Id == id);
            if (r != null)
            {
                r.Devices.Add(device);
                returnValue = true;
            }
            return returnValue;
        }

        public bool AddDeviceToRoom(int roomId, int deviceId)
        {
            bool returnValue = false;
            Room r = _dataContext.Rooms.Find(room => room.Id == roomId);
            if (r != null)
            {
                IDevice d = _dataContext.Devices.Find(device => device.Id == deviceId);
                if (d != null)
                {

                }
            }
            return returnValue;
        }

        public bool RemoveDeviceFromRoom(int roomId, IDevice device)
        {
            bool returnValue = false;
            Room r = _dataContext.Rooms.Find(room => room.Id == roomId);
            if (r != null)
            {
                returnValue = r.Devices.Remove(device);
            }
            return returnValue;
        }

        public bool RemoveDeviceFromRoom(int roomId, int deviceId)
        {
            bool returnValue = false;
            Room r = _dataContext.Rooms.Find(room => room.Id == roomId);
            if (r != null)
            {
                IDevice d = _dataContext.Devices.Find(device => device.Id == deviceId);
                if (d != null)
                {
                    returnValue = r.Devices.Remove(d);
                }
            }
            return returnValue;
        } 
        #endregion

        #region INamedRepository<Room>

        public bool Add(Room item)
        {
            _dataContext.Rooms.Add(item);
            return true;
        }

        public Room Get(string name)
        {
            return _dataContext.Rooms.Find(house => house.Name == name);
        }

        public IEnumerable<Room> Get()
        {
            return _dataContext.Rooms;
        }

        public Room Get(int id)
        {
            return _dataContext.Rooms.Find(house => house.Id == id);
        }

        public IEnumerable<Room> GetAll(string name)
        {
            return _dataContext.Rooms.FindAll(house => house.Name == name);
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
            return _dataContext.Rooms.RemoveAll(house => house.Name == name);
        }

        public bool Remove(int id)
        {
            return _dataContext.Rooms.RemoveAll(house => house.Id == id) > 0;
        }

        public bool Remove(Room item)
        {
            return _dataContext.Rooms.Remove(item);
        }

        public bool Update(int id, Room item)
        {
            Room found = _dataContext.Rooms.Find(house => house.Id == id);
            bool returnValue = false;
            if (found != null)
            {
                lock(_houseLock)
                {
                    found.Name = item.Name;
                    found.Devices = new List<IDevice>(item.Devices);
                }
                returnValue = true;
            }

            return returnValue;
        }

        public int UpdateAll(string name, Room item)
        {
            List<Room> found = (List<Room>)GetAll(name);
            foreach (var h in found)
            {
                lock (_houseLock)
                {
                    h.Name = item.Name;
                    h.Devices = new List<IDevice>(item.Devices);
                }
            }
            return found.Count;
        }
        #endregion
    }
}
