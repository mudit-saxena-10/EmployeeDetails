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
                
                throw;
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
                
                throw;
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
                
                throw;
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
                
                throw;
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
                    Department departmentModel = _context.tblDepartment.FirstOrDefault(x => x.DepartmentId == department.DepartmentId);
                    if(departmentModel!= null)
                    {
                        departmentModel.DepartmentName = department.DepartmentName;
                        departmentModel.LastUpdateDate = DateTime.Now;
                        departmentModel.Description = department.Description;
                        _context.SaveChanges(); 
                    }
                    else
                        result = false;
                }
                else
                    result=false;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return result;
        }
    }
}
