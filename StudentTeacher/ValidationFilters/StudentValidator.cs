using FluentValidation;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Validations
{
    public class NewStudentValidator : AbstractValidator<NewStudent>
    {
        public NewStudentValidator()
        {
            RuleFor(m => m.DateOfBirth).GreaterThan(DateTime.Now.AddYears(22))
                .WithMessage("Student's age may not be more than 22");
        }
    }
}
