using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.ReadModel
{
    public class EmployeeReadModel
    {
        public Guid Id { get; set; }// mã
        public string Name { get; set; }// tên
        public string Address { get; set; }// địa chỉ
        public string PhoneNumber { get; set; }// số điện thoại
        public float Salary { get; set; } // lương
        public bool IsDeleted { get; set; } // trạng thái làm việc
        [ForeignKey("Role")]
        public Guid Roles { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }// thuộc phòng ban

        public virtual RolesEmployeeReadModel Role { get; set; }
        // xác định là EmployeeReadModel sẽ có một RolesEmployeeReadModel ( trong trường hợp này Role sẽ là khóa ngoại )
        public virtual DepartmentReadModel Department { get; set; }

    }
}
