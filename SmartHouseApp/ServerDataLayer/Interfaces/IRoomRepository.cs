using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface IRoomRepository : INamedRepository<Room>
    {
        public bool AddDeviceToRoom(int id, IDevice device);
        public bool AddDeviceToRoom(int roomId, int deviceId); 
        public bool RemoveDeviceFromRoom(int roomId, IDevice device);
        public bool RemoveDeviceFromRoom(int roomId, int deviceId);
    }
}
