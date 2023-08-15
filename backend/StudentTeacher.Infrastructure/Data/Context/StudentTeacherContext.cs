using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentTeacher.Core.Entities;
using System.Reflection;

namespace StudentTeacher.Infrastructure.Data.Context
{
    public class StudentTeacherContext: DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public StudentTeacherContext(DbContextOptions<StudentTeacherContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<DateTimeOffset>()
                .HaveConversion<DateTimeOffsetToStringConverter>(); // SqlLite workaround for DateTimeOffset sorting

            configurationBuilder
                .Properties<decimal>()
                .HaveConversion<double>(); // SqlLite workaround for decimal aggregations
        }
    }
}
