using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.IRepositories
{
    public interface IDepartmentManager<T> where T : class
    {
        public Task<T> AddDataCommandAsync(T entity);
        public List<T> GetDataQuery();
        public Task<T> UpdateDataCommandAsync(T entity);
        public Task<T> DeleteDataCommandAsync(T entity);
    }
}
