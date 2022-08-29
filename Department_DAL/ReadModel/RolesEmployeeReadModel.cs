using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.ReadModel
{
    public class RolesEmployeeReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<EmployeeReadModel> Employees { get; set; }
        // xác định một RolesEmployeeReadModel sẽ là khóa ngoại của Employee
    }
}
