using System;

namespace LogicLayer
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string user) 
            : base("User " + user + " was not found!")
        { }
    }
}
