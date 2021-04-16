using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IDataRepository<T> where T : IData
    {
        public IEnumerable<T> Get();
        public T Get(int id);
        public T Add(T item);
        public int Remove(int id);
        public int Remove(T item);
        public int Update(int id, T item);
    }
}
