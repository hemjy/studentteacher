using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Interfaces.Core
{
    public interface ITeacherService
    {
        Task AddTeacherAsync(NewTeacher model);
        Task<PagedList<TeacherToReturn>> GetTeachersAsync(int pageNumber, int pageSize);
    }
}
