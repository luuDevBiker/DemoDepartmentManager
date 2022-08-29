using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_BUS.IRepositories
{
    public interface IDepartnmentManagerBus<T> where T : class
    {
        public Task<T> AddDataCommandAsync(T entity);
        public List<T> GetDataQuery();
        public Task<T> UpdateDataCommandAsync(T entity);
        public Task<T> DeleteDataCommandAsync(Guid id);
    }
}
