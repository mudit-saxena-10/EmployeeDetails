using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
