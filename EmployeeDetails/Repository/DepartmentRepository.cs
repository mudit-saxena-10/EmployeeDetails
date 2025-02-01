using DepartmentDetails.Repository.IRepository;
using EmployeeDetails.Data;
using EmployeeDetails.Model;
using EmployeeDetails.Repository.IRepository;

namespace EmployeeDetails.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateDepartment(Department department)
        {
            Boolean result = true;
            try
            {
                if (department != null)
                {
                    _context.tblDepartment.Add(department);
                    _context.SaveChanges();
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public bool DeleteDepartment(int id)
        {
            Boolean result = true;
            try
            {
                if (id > 0)
                {
                    Department department = _context.tblDepartment.FirstOrDefault(data => data.DepartmentId == id);
                    if (department != null)
                    {
                        department.Status = false;
                        _context.SaveChanges();
                    }
                    else
                        result = false;
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public List<Department> GetAllDepartmentsDetail()
        {
            List<Department> departments = new List<Department>();  
            try
            {
                departments = _context.tblDepartment.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                departments = null;
            }
            return departments;
        }

        public Department GetDepartmentDetailsById(int id)
        {
            Department department= new Department();
            try
            {
                if (id > 0)
                {
                    department= _context.tblDepartment.FirstOrDefault(x=> x.DepartmentId == id);
                }
                else
                    department = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                department = null;
            }
            return department;
        }

        public bool UpdateDepartment(Department department)
        {
            Boolean result = true;
            try
            {
                if (department != null && department.DepartmentId>0)
                {
                    _context.tblDepartment.Update(department);
                    _context.SaveChanges();
                }
                else
                    result=false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result= false;  
            }
            return result;
        }
    }
}
