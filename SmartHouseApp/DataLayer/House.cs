using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer
{
    class House : IData
    {
        int IData.Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
