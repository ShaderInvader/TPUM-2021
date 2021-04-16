using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface INamed : IData
    {
        public string Name { get; protected set; }
    }
}
