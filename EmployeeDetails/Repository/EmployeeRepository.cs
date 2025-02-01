using EmployeeDetails.Data;
using EmployeeDetails.Model;
using EmployeeDetails.Repository.IRepository;

namespace EmployeeDetails.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee GetEmployeeDetailsById(int id)
        {
              Employee employee = new Employee(); 
            try
            {
                 employee = _context.tblEmployee.FirstOrDefault(x => x.Id == id);
            }
            catch(Exception ex)
            {
                return null;
            }

            return employee;
        }


    }


}
