using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees {get;set;}
        public DbSet<Department> Departments { get; set; }
    }
}