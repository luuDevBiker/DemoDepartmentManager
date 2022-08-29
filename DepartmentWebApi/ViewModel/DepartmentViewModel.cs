using System;

namespace DepartmentWebApi.ViewModel
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ManagerId { get; set; }
    }
}
