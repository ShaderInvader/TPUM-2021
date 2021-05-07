using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogicLayer
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Tuple<double, double> Location { get; set; }
        public HouseDTO UserHouse { get; set; }
    }
}
