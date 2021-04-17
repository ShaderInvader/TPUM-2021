﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Interfaces;
using LogicLayer.DTOs;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
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

        public IEnumerable<RoomDTO> GetRoomsByName(string name)
        {
            IEnumerable<Room> rooms = _roomRepo.GetAll(name);
            List<RoomDTO> roomsDTOs = new List<RoomDTO>();
            foreach (var room in rooms)
            {
                roomsDTOs.Add(Mapper.Map(room));
            }

            return roomsDTOs;
        }
    }
}
