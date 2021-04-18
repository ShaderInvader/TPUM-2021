﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer
{
    public class User : INamed
    {
        public int Id { get; set; }
        // This field should be treated as a nickname
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Tuple<double, double> Location { get; set; }
    }
}
