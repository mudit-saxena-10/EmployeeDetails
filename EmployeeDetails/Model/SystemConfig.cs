using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDetails.Model
{
    public class SystemConfig
    {
        [Key]
        public int id{ get; set; }
        [Required]
        public Boolean EmployeeDeletion { get; set; }
        [Required]
        public Boolean DefaultDepartment { get; set; }
    }
}
