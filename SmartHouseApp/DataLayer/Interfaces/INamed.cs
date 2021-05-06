using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface INamed : IData
    {
        public string Name { get; set; }
    }
}
