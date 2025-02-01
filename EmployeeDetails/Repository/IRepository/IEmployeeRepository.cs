using EmployeeDetails.Model;

namespace EmployeeDetails.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployeeDetailsById(int id);
        public List<Employee> GetAllEmployeesDetail();

        public Boolean CreateEmployee(Employee employee);
        public Boolean UpdateEmployee(Employee employee);
        public Boolean DeleteEmployee(int id);

    }
}
