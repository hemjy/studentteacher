using Microsoft.AspNetCore.Authorization;
using StudentTeacher.Core.Interfaces.Core;
using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Core.Services;
using StudentTeacher.Infrastructure.Data.Context;
using StudentTeacher.Infrastructure.UnitOfWork;

namespace StudentTeacher
{
    public static class ConfigurationExtensions
    {
        public static void AddStudentTeacherServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("studentteacher");

            services.AddSqlite<StudentTeacherContext>(connectionString);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            
        }
    }
}
