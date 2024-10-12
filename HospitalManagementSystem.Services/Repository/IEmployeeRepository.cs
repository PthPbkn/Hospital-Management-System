using HospitalManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Repository
{
    public interface IEmployeeRepository
    {

        Task<List<Employees>> GetAllEmployees();

    }
}
