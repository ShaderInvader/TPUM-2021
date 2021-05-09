using System.Collections.Generic;
using ModelCommon.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface IDataRepository<T> where T : IData
    {
        public IEnumerable<T> Get();
        public T Get(int id);
        public bool Add(T item);
        public bool Remove(int id);
        public bool Update(int id, T item);
    }
}
