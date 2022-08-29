using Department_DAL.DepartmentDbContext;
using Department_DAL.IRepositories;
using Department_DAL.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.Repositories
{
    public class DepartmentService<T> : IDepartmentManager<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddDataCommandAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteDataCommandAsync(T entity)
        {
            _dbContext.Remove<T>(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public List<T> GetDataQuery()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> UpdateDataCommandAsync(T entity)
        {
            _dbContext.Update<T>(entity);
            await _dbContext.AddRangeAsync();
            return entity;
        }
    }
}
