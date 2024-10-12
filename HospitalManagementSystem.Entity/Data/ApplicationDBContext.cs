using HospitalManagementSystem.Entity.Models;
using HospitalManagementSystem.Entity.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity.Data
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) 
        {
        
        
        }

        public DbSet<Employees> EmployeesSet { get; set; }

        
    }
    
}
