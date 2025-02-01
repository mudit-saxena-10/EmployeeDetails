using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; } 
        public int EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public int DepartmentId { get; set; }
        public Boolean Status { get; set; } 
    }
}
