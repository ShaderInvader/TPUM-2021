using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.DTOs;

namespace LogicLayer.Interfaces
{
    public interface IHouseService
    {
        HouseDTO GetHouse(int id);
        IEnumerable<HouseDTO> GetHouses();
        IEnumerable<HouseDTO> GetHousesByName(string name);
    }
}
