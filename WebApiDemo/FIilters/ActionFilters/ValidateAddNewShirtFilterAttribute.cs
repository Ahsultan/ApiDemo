using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.FIilters.ActionFilters
{
    public class ValidateAddNewShirtFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _context;

        public ValidateAddNewShirtFilterAttribute(ApplicationDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null. ");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingShirt = _context.Shirts.Any(x =>
                x.Brand.ToLower() == shirt.Brand.ToLower() &&
                x.Gender.ToLower() == shirt.Gender.ToLower() &&
                x.Color.ToLower() == shirt.Color.ToLower() &&
                x.Size.Value == shirt.Size.Value);

                if (existingShirt)
                {
                    context.ModelState.AddModelError("Shirt", "Shirt already Exist.");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);

                }
            }
        }
    }
}
