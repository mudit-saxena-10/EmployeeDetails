using AutoMapper;
using DepartmentDetails.Repository.IRepository;
using EmployeeDetails.Model;
using EmployeeDetails.Model.DTOs;
using EmployeeDetails.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllDepartment")]
        public ResponseDto GetAllDepartment()
        {
            ResponseDto result = new ResponseDto();
            try
            {
                List<Department> departments=_departmentRepository.GetAllDepartmentsDetail();
                if(departments != null)
                {
                    result.Data= _mapper.Map<List<DepartmentDto>>(departments);
                    result.ResponseCode = 200;
                    if (departments.Count == 0)
                        result.Comment = "No Department Found.";
                    else
                        result.Comment = "All Department Data Pushed.";
                }
                else
                {
                    result.ResponseCode = 201;
                    result.Comment = "Department Not Found.";
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment= ex.Message;
            }
            return result;
        }

        [HttpGet("GetDepartmentById/{id:int}")]
        public ResponseDto GetDepartmentById(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (id > 0)
                {
                    result.Data = _departmentRepository.GetDepartmentDetailsById(id);
                    if(result.Data!= null)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Department Data Pushed.";
                    }
                    else
                    {
                        result.Data= null;
                        result.ResponseCode = 201;
                        result.Comment = "Department Not Found.";
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
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
        [HttpPost("CreateDepartment")]
        public ResponseDto CreateDepartment([FromBody]DepartmentDto department)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if(department != null)
                {
                    Department departmentModel = _mapper.Map<Department>(department);   
                    var data = _departmentRepository.CreateDepartment(departmentModel);
                    result.Data= data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result.ResponseCode = 500;
                result.Comment = ex.Message;
            }
            return result;
        }
        [HttpPut("UpdateDepartment")]
        public ResponseDto UpdateDepartment(Department department)
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
        [HttpPatch("DeleteDepartment/{id:int}")]
        public ResponseDto DeleteDepartment(int id)
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
