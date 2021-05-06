using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public interface IRoomService
    {
        RoomDTO GetRoom(int id);
        IEnumerable<RoomDTO> GetRooms();
        IEnumerable<RoomDTO> GetRoomsByName(string name);
    }
}
