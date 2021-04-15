using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    abstract class SmartDevice : IData
    {
        int IData.Id { get; set; }
        public string Name { get; protected set; }
        public bool Enabled { get; protected set; }
    }
}
