using System;
using System.Collections.Generic;
using System.Text;

namespace ModelCommon.Interfaces
{
    public interface INamedRepository<T> : IDataRepository<T> where T : INamed
    {
        public T Get(string name);
        public IEnumerable<T> GetAll(string name);
        public int GetFirstId(string name);
        public int[] GetIds(string name);
        public int Remove(string name);
        public bool UpdateFirst(string name, T item);
        public int UpdateAll(string name, T item);
    }
}
