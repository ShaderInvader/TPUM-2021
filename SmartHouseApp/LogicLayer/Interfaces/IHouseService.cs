using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public interface IHouseService
    {
        HouseDTO GetHouse(int id);
        IEnumerable<HouseDTO> GetHouses();
        IEnumerable<HouseDTO> GetHousesByName(string name);
    }
}
