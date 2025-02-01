using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDetails.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }  
        
        public int EmployeeAge { get; set; } = 0;
        [Required]
        public int EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Boolean Status { get; set; } = true;
        public virtual Department Department { get; set; }

        
    }
}
