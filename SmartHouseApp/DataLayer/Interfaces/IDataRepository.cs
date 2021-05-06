using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IDataRepository<T> where T : IData
    {
        public IEnumerable<T> Get();
        public T Get(int id);
        public void Add(T item);
        public int Remove(int id);
        public bool Remove(T item);
        public bool Update(int id, T item);
    }
}
