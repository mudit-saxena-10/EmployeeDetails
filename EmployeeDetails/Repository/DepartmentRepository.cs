using EmployeeDetails.Data;
using EmployeeDetails.Repository.IRepository;

namespace EmployeeDetails.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context=context;
        }
    }
}
