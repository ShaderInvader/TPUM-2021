using System;
using System.Collections.Generic;
using System.Text;
using ClientLogicLayer.InternalDTOs;

namespace LogicLayer.Interfaces
{
    public interface IRoomService
    {
        RoomDTO GetRoom(int id);
        IEnumerable<RoomDTO> GetRooms();
        IEnumerable<RoomDTO> GetRoomsByName(string name);
    }
}
