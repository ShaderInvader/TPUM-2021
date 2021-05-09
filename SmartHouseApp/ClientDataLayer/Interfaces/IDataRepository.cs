using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ModelCommon.Interfaces;

namespace ClientDataLayer.Interfaces
{
    public interface IDataRepository<T> where T : IData
    {
        public event Action DataChanged;
        public IEnumerable<T> Get();
        public Task Refresh();
        public T Get(int id);
        public Task<bool> Add(T item);
        public bool Remove(int id);
        public bool Update(int id, T item);
    }
}
