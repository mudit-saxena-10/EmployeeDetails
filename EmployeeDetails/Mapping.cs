using AutoMapper;
using EmployeeDetails.Model;
using EmployeeDetails.Model.DTOs;

namespace EmployeeDetails
{
    public class Mapping
    {
        public static MapperConfiguration RegisterMapping()
        {
            MapperConfiguration mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Department,DepartmentDto>();
                config.CreateMap<DepartmentDto, Department>();
                config.CreateMap<Employee, EmployeeDto>();
                config.CreateMap<EmployeeDto, Employee>();
            });
            return mapper;

        }
    }
}
