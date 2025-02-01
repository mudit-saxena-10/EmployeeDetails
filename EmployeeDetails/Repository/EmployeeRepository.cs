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

        public bool CreateEmployee(Employee employee)
        {
            Boolean result = true;
            try
            {
                if (employee != null)
                {
                    _context.tblEmployee.Add(employee);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = false;
            }
            return result;
        }

        public bool DeleteEmployee(int id)
        {
            Boolean result = true;
            try
            {
                if (id > 0)
                {
                    Employee employee = _context.tblEmployee.FirstOrDefault(x => x.Id == id);
                    if (employee != null)
                    {
                        employee.Status = false;
                        _context.SaveChanges();
                    }
                    else
                        return false;
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public List<Employee> GetAllEmployeesDetail()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _context.tblEmployee.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                employees = null;
            }
            return employees;
        }

        public Employee GetEmployeeDetailsById(int id)
        {
            Employee employee = new Employee();
            try
            {
                if (id > 0)
                {
                    employee = _context.tblEmployee.FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    employee = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                employee = null;
            }

            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            Boolean result = true;
            try
            {
                if (employee != null && employee.Id > 0)
                {
                    _context.tblEmployee.Update(employee);
                    _context.SaveChanges();
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
    }


}
