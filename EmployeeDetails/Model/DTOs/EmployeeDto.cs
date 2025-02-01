using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model.DTOs
{
    public class EmployeeDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }
        [Range(1000000000, 9999999999)]
        public long EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public int DepartmentId { get; set; }
        public Boolean Status { get; set; } 
    }
}
