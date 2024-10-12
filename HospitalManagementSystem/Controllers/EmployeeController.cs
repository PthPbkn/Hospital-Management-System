using HospitalManagementSystem.Entity.Data;
using HospitalManagementSystem.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class EmployeeController :Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _repository.GetAllEmployees();
            return View(employee);
        }

    }
}
