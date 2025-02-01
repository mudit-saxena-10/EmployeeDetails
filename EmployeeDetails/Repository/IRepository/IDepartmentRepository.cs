using EmployeeDetails.Model;

namespace DepartmentDetails.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        public Department GetDepartmentDetailsById(int id);
        public List<Department> GetAllDepartmentsDetail();

        public Boolean CreateDepartment(Department Department);
        public Boolean UpdateDepartment(Department Department);
        public Boolean DeleteDepartment(int id);
    }
}
