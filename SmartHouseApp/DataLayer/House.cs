using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer
{
    public class House : INamed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
