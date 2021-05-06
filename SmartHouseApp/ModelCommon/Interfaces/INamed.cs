using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCommon.Interfaces
{
    public interface INamed : IData
    {
        public string Name { get; set; }
    }
}
