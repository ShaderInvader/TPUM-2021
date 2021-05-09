using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;
using ModelCommon;
using ServerDataLayer;
using ServerDataLayer.Interfaces;

namespace ServerLogicLayer
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repoReference = null;
        public RoomService()
        {
            if(_repoReference == null)
            {
                _repoReference = new RoomRepository();
                _repoReference.Add(new Room() { Id = 0, Name = "Kitchen", Devices = new List<IDevice>() });
                _repoReference.Add(new Room() { Id = 1, Name = "Living Room", Devices = new List<IDevice>() });
                _repoReference.Add(new Room() { Id = 2, Name = "Bathroom", Devices = new List<IDevice>() });
                _repoReference.Add(new Room() { Id = 3, Name = "Play Room", Devices = new List<IDevice>() });

            }
        }

        public RoomService(IRoomRepository repository)
        {
            _repoReference = repository;
        }

        #region IRoomService
        public async Task<bool> AddDeviceToRoom(RoomDTO referenceRoom, ExampleDeviceDTO newDevice)
        {
            return await Task.FromResult(_repoReference.AddDeviceToRoom(referenceRoom.Id, Mapper.Map(newDevice)));
        }

        public async Task<bool> AddRoom(RoomDTO roomToAdd)
        {
            return await Task.FromResult(_repoReference.Add(Mapper.Map(roomToAdd)));
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            return await Task.FromResult(Mapper.Map(_repoReference.Get(id)));
        }

        public async Task<IEnumerable<RoomDTO>> GetRooms()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            var ro = _repoReference.Get();
            foreach(var r in ro)
            {
                rooms.Add(Mapper.Map(r));
            }
            return await Task.FromResult(rooms);
        }

        public async Task<bool> RemoveDeviceFromRoom(RoomDTO referenceRoom, ExampleDeviceDTO newDevice)
        {
            return await Task.FromResult(_repoReference.RemoveDeviceFromRoom(referenceRoom.Id, Mapper.Map(newDevice)));
        }

        public async Task<bool> RemoveRoom(RoomDTO roomToRemove)
        {
            return await Task.FromResult(_repoReference.Remove(roomToRemove.Id));
        }

        public async Task<bool> UpdateRoom(int id, RoomDTO newRoomValues)
        {
            return await Task.FromResult(_repoReference.Update(id, Mapper.Map(newRoomValues)));
        } 
        #endregion
    }
}
