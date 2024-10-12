using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entity.Models
{
    [Table("tbl_Employee")]
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
    }
}
