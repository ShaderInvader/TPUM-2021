using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using ModelCommon;
using ModelCommon.Interfaces;

namespace LogicLayer
{
    public class HouseService : IHouseService
    {
        private readonly INamedRepository<Room> _houseRepo;

        public HouseService(INamedRepository<Room> houseRepository)
        {
            _houseRepo = houseRepository;
        }

        public HouseDTO GetHouse(int id)
        {
            return Mapper.Map(_houseRepo.Get(id));
        }

        public IEnumerable<HouseDTO> GetHouses()
        {
            IEnumerable<Room> houses = _houseRepo.Get();
            List<HouseDTO> housesDTOs = new List<HouseDTO>();
            foreach (var house in houses)
            {
                housesDTOs.Add(Mapper.Map(house));
            }

            return housesDTOs;
        }

        public IEnumerable<HouseDTO> GetHousesByName(string name)
        {
            IEnumerable<Room> houses = _houseRepo.GetAll(name);
            List<HouseDTO> housesDTOs = new List<HouseDTO>();
            foreach (var house in houses)
            {
                housesDTOs.Add(Mapper.Map(house));
            }

            return housesDTOs;
        }
    }
}
