using EfCoreApiDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreApiDemo.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) 
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
