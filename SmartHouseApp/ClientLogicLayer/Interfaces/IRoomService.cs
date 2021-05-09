using System.Collections.Generic;
using ClientLogicLayer.InternalDTOs;

namespace LogicLayer.Interfaces
{
    public interface IRoomService
    {
        RoomDTO GetRoom(int id);
        IEnumerable<RoomDTO> GetRooms();
    }
}
