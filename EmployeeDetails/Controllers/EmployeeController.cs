using DepartmentDetails.Repository.IRepository;
using EmployeeDetails.Model.DTOs;
using EmployeeDetails.Model;
using EmployeeDetails.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EmployeeDetails.Repository;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllEmployee")]
        public ResponseDto GetAllEmployee()
        {
            ResponseDto result = new ResponseDto();
            try
            {
                List<Employee> Employees = _employeeRepository.GetAllEmployeesDetail();
                if (Employees != null)
                {
                    result.Data = _mapper.Map<List<EmployeeDto>>(Employees);
                    result.ResponseCode = 200;
                    if (Employees.Count == 0)
                        result.Comment = "No Employee Found.";
                    else
                        result.Comment = "All Employee Data Pushed.";
                }
                else
                {
                    result.ResponseCode = 201;
                    result.Comment = "Employee Not Found.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                result.Data = null;
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
            }
            return result;
        }

        [HttpGet("GetEmployeeById/{id:int}")]
        public ResponseDto GetEmployeeById(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (id > 0)
                {
                    Employee Employee = _employeeRepository.GetEmployeeDetailsById(id);

                    if (Employee != null)
                    {
                        result.Data = _mapper.Map<EmployeeDto>(Employee);
                        result.ResponseCode = 200;
                        result.Comment = "Employee Data Pushed.";
                    }
                    else
                    {
                        result.Data = null;
                        result.ResponseCode = 201;
                        result.Comment = "Employee Not Found.";
                    }

                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Received Invalid Data.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
            }
            return result;
        }
        [HttpPost("CreateEmployee")]
        public ResponseDto CreateEmployee([FromBody]EmployeeDto employee)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (employee != null)
                {
                    Employee EmployeeModel = _mapper.Map<Employee>(employee);
                    Boolean status = _employeeRepository.CreateEmployee(EmployeeModel);
                    result.Data = status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Inserted Employee.";
                    }
                    else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Inserted Employee.";
                    }
                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Invalid or No Employee Received.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                result.Data = null;
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
            }
            return result;
        }
        [HttpPut("UpdateEmployee")]
        public ResponseDto UpdateEmployee([FromBody]EmployeeWithId_Dto employee)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (employee != null)
                {
                    Employee EmployeeModel = _mapper.Map<Employee>(employee);
                    Boolean status = _employeeRepository.UpdateEmployee(EmployeeModel);
                    result.Data = status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Updated Employee.";
                    }
                    else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Updated Employee.";
                    }
                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Invalid or No Employee Received.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                result.Data = null;
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
            }
            return result;
        }
        [HttpPatch("DeleteEmployee/{id:int}")]
        public ResponseDto DeleteEmployee(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (id > 0)
                {
                    Boolean status = _employeeRepository.DeleteEmployee(id);
                    result.Data = status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Employee Deleted.";
                    }
                    else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Employee Deleted.";
                    }
                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Received Invalid Data.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                result.Data = null;
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
            }
            return result;
        }
    }
}
