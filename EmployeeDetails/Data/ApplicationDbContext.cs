using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Employee>().HasData(new Employee { 
        //        Id = 1,
        //        EmployeeName= "Name",
        //        EmployeeAddress="Address",
        //        EmployeeAge=10,
        //        EmployeePhone=1234567891,
        //        EmployeeId=1,
        //        CreationDate= DateTime.Now,
        //        LastUpdateDate= DateTime.Now,
        //        Status=true

        //    });
        //}
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Department> tblDepartment { get; set; }
    }
}
