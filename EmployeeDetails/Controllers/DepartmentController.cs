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
                Console.WriteLine(ex.InnerException.ToString());
                result.Data = null;
                result.ResponseCode = 500;
                result.Comment= ex.InnerException.ToString();
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
                    Department department= _departmentRepository.GetDepartmentDetailsById(id);
                    
                    if(department != null)
                    {
                        result.Data = _mapper.Map<DepartmentDto>(department);
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
                Console.WriteLine(ex.InnerException.ToString());
                result.ResponseCode = 500;
                result.Comment = ex.InnerException.ToString();
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
                    Boolean status = _departmentRepository.CreateDepartment(departmentModel);
                    result.Data= status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Inserted Department.";
                    }else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Inserted Department.";
                    }
                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Invalid or No Department Received.";
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
        [HttpPut("UpdateDepartment")]
        public ResponseDto UpdateDepartment([FromBody]DepartmentWithId_Dto department)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (department != null)
                {
                    Department departmentModel = _mapper.Map<Department>(department);
                    Boolean status = _departmentRepository.UpdateDepartment(departmentModel);
                    result.Data = status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Updated Department.";
                    }
                    else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Updated Department.";
                    }
                }
                else
                {
                    result.Data = null;
                    result.ResponseCode = 201;
                    result.Comment = "Invalid or No Department Received.";
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
        [HttpPatch("DeleteDepartment/{id:int}")]
        public ResponseDto DeleteDepartment(int id)
        {
            ResponseDto result = new ResponseDto();
            try
            {
                if (id > 0)
                {
                    Boolean status = _departmentRepository.DeleteDepartment(id);
                    result.Data = status;
                    if (status)
                    {
                        result.ResponseCode = 200;
                        result.Comment = "Successfully Department Deleted.";
                    }
                    else
                    {
                        result.ResponseCode = 201;
                        result.Comment = "UnSuccessfully Department Deleted.";
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
