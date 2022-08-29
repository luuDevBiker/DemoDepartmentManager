using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.ReadModel
{
    public class DepartmentReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ManagerId { get; set; }
        public ICollection<EmployeeReadModel> Employees { get; set; }
    }
}
