using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model.DTOs
{
    public class SystemConfig
    {
        [Required]
        public Boolean EmployeeDeletion { get; set; } = false;
        [Required]
        public Boolean DefaultDepartment { get; set; } = true;
    }
}
