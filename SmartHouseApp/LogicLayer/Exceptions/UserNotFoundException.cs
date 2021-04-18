﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string user) 
            : base("User " + user + " was not found!")
        { }
    }
}
