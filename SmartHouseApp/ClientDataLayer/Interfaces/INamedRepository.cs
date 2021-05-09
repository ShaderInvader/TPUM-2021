using System.Collections.Generic;
using ModelCommon.Interfaces;

namespace ClientDataLayer.Interfaces
{
    public interface INamedRepository<T> : IDataRepository<T> where T : INamed
    {
        public T Get(string name);
        public IEnumerable<T> GetAll(string name);
        public int Remove(string name);
    }
}
