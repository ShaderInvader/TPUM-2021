using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface IDataRepository<T> where T : IData
    {
        public IEnumerable<T> Get();
        public T Get(int id);
        public bool Add(T item);
        public bool Remove(int id);
        public bool Remove(T item);
        public bool Update(int id, T item);
    }
}
