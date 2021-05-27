using System;

namespace ClientLogicLayer
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string user) 
            : base("User " + user + " was not found!")
        { }
    }
}
