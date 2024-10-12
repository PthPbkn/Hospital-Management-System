using HospitalManagementSystem.Entity.Data;
using HospitalManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _context.EmployeesSet.ToListAsync();
        }
    }
}
