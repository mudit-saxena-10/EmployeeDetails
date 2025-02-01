using DepartmentDetails.Repository.IRepository;
using EmployeeDetails.Model.DTOs;
using EmployeeDetails.Model;
using EmployeeDetails.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public ResponseDto GetAllEmployee()
        {
            ResponseDto result = new ResponseDto();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }

        [HttpGet("{id:int}")]
        public ResponseDto GetEmployeeById(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
        [HttpPost]
        public ResponseDto CreateEmployee(Employee Employee)
        {
            ResponseDto result = new ResponseDto();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
        [HttpPut]
        public ResponseDto UpdateEmployee(Employee Employee)
        {
            ResponseDto result = new ResponseDto();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
        [HttpPatch("{id:int}")]
        public ResponseDto DeleteEmployee(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
    }
}
