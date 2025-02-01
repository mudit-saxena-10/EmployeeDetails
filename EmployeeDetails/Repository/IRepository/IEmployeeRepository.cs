using EmployeeDetails.Model;

namespace EmployeeDetails.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeDetailsById(int id);
    }
}
