using System;
using System.Collections.Generic;
using System.Text;
using ModelCommon.Interfaces;
using ServerDataLayer.Interfaces;

namespace ServerDataLayer.Interfaces
{
    public interface INamedRepository<T> : IDataRepository<T> where T : INamed
    {
        public T Get(string name);
        public IEnumerable<T> GetAll(string name);
        public int[] GetIds(string name);
        public int Remove(string name);
        public int UpdateAll(string name, T item);
    }
}
