
using AutoMapper;
using DepartmentDetails.Repository.IRepository;
using EmployeeDetails.Data;
using EmployeeDetails.Repository;
using EmployeeDetails.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                {
                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
                });
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            IMapper mapper = Mapping.RegisterMapping().CreateMapper();
            builder.Services.AddSingleton(mapper); 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
