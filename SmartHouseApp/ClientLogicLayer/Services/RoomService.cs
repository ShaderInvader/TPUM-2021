using System.Collections.Generic;
using ClientDataLayer;
using ClientDataLayer.Interfaces;
using ClientLogicLayer.Interfaces;
using ClientLogicLayer.InternalDTOs;

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
            IEnumerable<Room> rooms = _roomRepo.Get();
            List<RoomDTO> roomsDTOs = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                roomsDTOs.Add(Mapper.Map(room));
            }

            return roomsDTOs;
        }
    }
}
