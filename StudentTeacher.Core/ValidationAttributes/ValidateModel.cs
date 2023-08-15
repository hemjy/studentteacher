using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace StudentTeacher.ValidationFilters
{
    public class ValidateModelAttribute  : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            

            context.ModelState.AddModelError(
                "firmwareVersion",
                "The firmware value does not match semantic versioning format.");

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
