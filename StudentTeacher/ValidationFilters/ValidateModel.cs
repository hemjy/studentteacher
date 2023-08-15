using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentTeacher.Core.DTOs;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace StudentTeacher.ValidationFilters
{
    public class ValidateModelAttribute  : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string actionNameStudent = "AddNewStudent";
            string actionNameTeacher = "AddNewTeacher";
            if (context.ActionDescriptor.DisplayName.Contains(actionNameStudent)) {
                NewStudent model = context.ActionArguments["model"] as NewStudent;
                if (model != null && model.DateOfBirth <= DateTime.UtcNow.AddYears(-22)) {
                    context.ModelState.AddModelError(
                   "Date of Birth",
                   "age may not be more than 22");
                }
            }
            if (context.ActionDescriptor.DisplayName.Contains(actionNameTeacher))
            {
                NewTeacher model = context.ActionArguments["model"] as NewTeacher;
                if (model != null && model.DateOfBirth >= DateTime.UtcNow.AddYears(-21)) {
                    context.ModelState.AddModelError(
                    "Date of Birth",
                    "age may not be less than 21");
                }
            }
            

            var vpd = new ValidationProblemDetails(context.ModelState);

            context.Result = new BadRequestObjectResult(vpd);
        }
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    // our code before action executes
        //}
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    // our code after action executes
        //}
    }
}
