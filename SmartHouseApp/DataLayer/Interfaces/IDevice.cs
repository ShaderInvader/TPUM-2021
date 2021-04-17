using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Interfaces;

namespace DataLayer.Interfaces
{
    public interface IDevice : INamed
    {
        public bool Enabled { get; set; }
    }
}
