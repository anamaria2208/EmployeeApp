using API.Data.Repositories.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly CompanyContext _context;
        public EmployeeRepository(CompanyContext context)
        {
            _context = context;   
        }

        public async Task Add(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Update(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}