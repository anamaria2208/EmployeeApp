using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Repositories.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly CompanyContext _context;
        public DepartmentRepository(CompanyContext context)
        {
            _context = context;
        }
        public async Task Add(Department entity)
        {
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Department entity)
        {
            _context.Departments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Update(Department entity)
        {
            _context.Departments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}