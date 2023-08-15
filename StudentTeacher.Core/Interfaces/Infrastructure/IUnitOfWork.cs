

namespace StudentTeacher.Core.Interfaces.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        Task<int> SaveAsync();
    
    }
}
