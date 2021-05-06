using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDevice : INamed
    {
        public bool Enabled { get; set; }
    }
}
