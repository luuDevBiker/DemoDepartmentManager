using Department_DAL.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_DAL.DepartmentDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DepartmentReadModel> DepartmentReadModels { get; set; }
        public DbSet<EmployeeReadModel> EmployeeReadModels { get; set; }
        public DbSet<RolesEmployeeReadModel> RolesEmployeeReadModels { get; set; }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<DepartmentReadModel>
            // => là để setting cho đối tượng DepartmentReadModel khi tạo bảng trong Database
            modelBuilder.Entity<DepartmentReadModel>(builder =>
            {
                // builder => đại diện cho đối tượng DepartmentReadModel "các setting sẽ được xác định ở dưới
                builder.ToTable("Departments");
                // ToTable => sẽ set tên cho bảng
                builder.HasKey(entity => entity.Id);
                // entity đại diện cho một bản ghi ở trong table departments
                // HasKey => sẽ set Id là khóa chính cho bảng departments
                builder.Property(entity => entity.Name).IsUnicode();
                // Property => xác định cái thuộc tính của bảng
                // IsUnicode => set thuộc tính được xác định bỏi "Property" là Unique ( là duy nhất )
            });

            modelBuilder.Entity<RolesEmployeeReadModel>(builder =>
            {
                builder.ToTable("Roles");
                builder.HasKey(entity => entity.Id);
                builder.Property(entity => entity.Name).IsUnicode().IsRequired();
                // IsRequired => xác định thuộc tính "Name" sẽ không được Null
            });

            modelBuilder.Entity<EmployeeReadModel>(builder =>
            {
                builder.ToTable("Employees");
                builder.HasKey(entity => entity.Id);
                builder.HasOne(entity => entity.Department).WithMany(entity => entity.Employees);
                // EmployeeReadModel sẽ có một DepartmentReadModel
                // và với một DepartmentReadModel sẽ có nhiều EmployeeReadModel
                builder.HasOne(entity => entity.Role).WithMany(entity => entity.Employees);
            });
        }
    }
}
