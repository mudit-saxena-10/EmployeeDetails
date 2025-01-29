using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Department> tblDepartment { get; set; }
    }
}
