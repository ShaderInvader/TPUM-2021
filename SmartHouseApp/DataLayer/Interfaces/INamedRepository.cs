using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface INamedRepository : IDataRepository<INamed>
    {
        public INamed Get(string name);
        public int GetFirstId(string name);
        public int[] GetIds(string name);
        public int Remove(string name);
        public bool UpdateFirst(string name, INamed item);
        public int UpdateAll(string name, INamed item);
    }
}
