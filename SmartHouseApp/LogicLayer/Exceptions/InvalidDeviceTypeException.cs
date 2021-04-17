using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Exceptions
{
    public class InvalidDeviceTypeException : Exception
    {
        public InvalidDeviceTypeException(string type) : base(String.Format("Invalid device type {0}", type)) { }
    }
}
