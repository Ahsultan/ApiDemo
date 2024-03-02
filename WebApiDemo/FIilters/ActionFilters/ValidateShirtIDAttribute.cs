using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.FIilters.ActionFilters
{
    public class ValidateShirtIDAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public ValidateShirtIDAttribute(ApplicationDbContext db)
        {
            _db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else
                {
                    var shirt = _db.Shirts.Find(shirtId.Value);

                    if (shirt == null)
                    {
                        context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                    }
                    else
                    {
                        context.HttpContext.Items["shirt"] = shirt;
                    }
                }
            }
        }
    }
}
