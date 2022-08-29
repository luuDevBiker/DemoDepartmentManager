using Department_BUS.IRepositories;
using Department_DAL.IRepositories;
using Department_DAL.ReadModel;
using DepartmentWebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentWebApi.Controllers
{
    [Route("api/[controller]")]// xác dịnh cấu trúc đường link api Departments thay cho [controller]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartnmentManagerBus<DepartmentReadModel> _manager;
        public DepartmentsController(IDepartnmentManagerBus<DepartmentReadModel> manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        [HttpGet]
        public Task<List<DepartmentReadModel>> GetAsync()
        {
            var results = _manager.GetDataQuery();
            return Task.FromResult(results);
        }
        [HttpPost]
        public async Task<DepartmentReadModel> AddAsync(DepartmentViewModel viewModel)
        {
            var data = new DepartmentReadModel()
            {
                Id = Guid.NewGuid(),
                Address = viewModel.Address,
                IsDeleted = false,
                ManagerId = viewModel.ManagerId,
                Name = viewModel.Name
            };
            var result = await _manager.AddDataCommandAsync(data);
            return result;
        }
    }
}
