using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EngSchool.Presentation.ActionFilters
{
    public class ValidationFilterAttribute: IActionFilter
    {
        public ValidationFilterAttribute()
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var attribute = context.ActionArguments.SingleOrDefault(c=>c.Value.ToString().Contains("Dto")).Value;
            if (attribute is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller {controller}, action {action}");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
