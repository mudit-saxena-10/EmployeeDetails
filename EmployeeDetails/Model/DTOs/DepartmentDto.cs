using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }
    }
}
