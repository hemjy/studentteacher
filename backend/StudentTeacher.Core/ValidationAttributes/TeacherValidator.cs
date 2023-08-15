using FluentValidation;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;

namespace StudentTeacher.Validations
{
    public class NewTeacherValidator : AbstractValidator<NewTeacher>
    {
        public NewTeacherValidator() {
            RuleFor(m => m.DateOfBirth ).LessThan(DateTime.Now.AddYears(21))
                .WithMessage("Teacher's age may not be less than 21");
            
            RuleFor(m => m.Title).Empty()
                .Must(m => ValidateTitle(m))
               .WithMessage($"Title can either be [{Titles}]");
        }
        public string Titles => "Mr, Mrs ,Miss ,Dr ,Prof";
        public bool ValidateTitle(string title)
        {
            if(string.IsNullOrEmpty(title)) return false;
            return Titles.Contains(title, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
