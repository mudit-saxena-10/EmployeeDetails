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
        public Boolean Status { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
