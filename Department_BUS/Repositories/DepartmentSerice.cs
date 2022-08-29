using Department_BUS.IRepositories;
using Department_DAL.IRepositories;
using Department_DAL.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_BUS.Repositories
{
    public class DepartmentSerice : IDepartnmentManagerBus<DepartmentReadModel>
    {
        private readonly IDepartmentManager<DepartmentReadModel> _manager;

        public DepartmentSerice(IDepartmentManager<DepartmentReadModel> manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public async Task<DepartmentReadModel> AddDataCommandAsync(DepartmentReadModel entity)
        {
            var result = await _manager.AddDataCommandAsync(entity);
            return result;
        }

        public async Task<DepartmentReadModel> DeleteDataCommandAsync(Guid id)
        {
            var entity = _manager.GetDataQuery().FirstOrDefault(entity => Guid.Equals(entity.Id, id));
            entity.IsDeleted = true;
            var result = _manager.DeleteDataCommandAsync(entity);
            return await result;
        }

        public List<DepartmentReadModel> GetDataQuery()
        {
            return _manager.GetDataQuery();
        }

        public async Task<DepartmentReadModel> UpdateDataCommandAsync(DepartmentReadModel entity)
        {
            var result = await _manager.UpdateDataCommandAsync(entity);
            return result;
        }
    }
}
