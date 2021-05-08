﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogicLayer
{
    public interface IRoomService
    {
        Task<RoomDTO> GetRoom(int id);
        Task<IEnumerable<RoomDTO>> GetRooms();
        Task<IEnumerable<RoomDTO>> GetRoomsByName(string name);
        Task<bool> AddRoom(RoomDTO roomToAdd);
        Task<bool> RemoveRoom(RoomDTO roomToRemove);
        Task<bool> UpdateRoom(int id, RoomDTO newRoomValues);
        Task<bool> AddDeviceToRoom(RoomDTO referenceRoom, ExampleDeviceDTO newDevice);
        Task<bool> RemoveDeviceFromRoom(RoomDTO referenceRoom, ExampleDeviceDTO newDevice);
    }
}
