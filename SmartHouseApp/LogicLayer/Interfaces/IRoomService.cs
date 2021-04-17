using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.DTOs;

namespace LogicLayer.Interfaces
{
    interface IRoomService
    {
        RoomDTO GetRoom(int id);
        IEnumerable<RoomDTO> GetRooms();
        IEnumerable<RoomDTO> GetRoomsByName(string name);
    }
}
