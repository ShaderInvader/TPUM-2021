using System.Collections.Generic;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.InternalDTOs;
using LogicLayer.Interfaces;
using ModelCommon;
using ModelCommon.Interfaces;

namespace ClientLogicLayer.Services
{
    public class RoomService : IRoomService
    {
        private readonly INamedRepository<Room> _roomRepo;

        public RoomService(INamedRepository<Room> roomRepository)
        {
            _roomRepo = roomRepository;
        }

        public RoomDTO GetRoom(int id)
        {
            return Mapper.Map(_roomRepo.Get(id));
        }

        public IEnumerable<RoomDTO> GetRooms()
        {
            IEnumerable<Room> rooms = _roomRepo.Get().Result;
            List<RoomDTO> roomsDTOs = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                roomsDTOs.Add(Mapper.Map(room));
            }

            return roomsDTOs;
        }
    }
}
