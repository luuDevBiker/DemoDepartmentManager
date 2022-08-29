using Department_BUS.IRepositories;
using Department_BUS.Repositories;
using Department_DAL.DepartmentDbContext;
using Department_DAL.IRepositories;
using Department_DAL.ReadModel;
using Department_DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// phải đọc thêm và dependency injection 
// mục đích để giảm sự phụ thuộc giữa các class với nhau
// bình thường add class và một class thường sẽ => ClassA = new ClassA() ngay trong ClassB
// bây giờ sẽ add private readonly ClassA trong ClassB
builder.Services.AddScoped(typeof(IDepartmentManager<>), typeof(DepartmentService<>));
// DependencyInjection Add generic interface IDepartmentManager vào generic class DepartmentService khi mà chương trình chạy
// 
builder.Services.AddScoped(typeof(IDepartnmentManagerBus<DepartmentReadModel>), typeof(DepartmentSerice));
// DependencyInjection Add IDepartnmentManagerBus vào DepartmentSerice khi mà chương trình chạy

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
