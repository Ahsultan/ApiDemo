using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;

namespace WebApiDemo.FIilters.ExceptionFilters
{
    public class ShirtUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public ShirtUpdateExceptionsFilterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var shirtId = context.RouteData.Values["id"] as string;

            if(int.TryParse(shirtId, out int shirtid))
            {
                if(_db.Shirts.FirstOrDefault(x => x.ShirtId == shirtid) == null)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId doesn't exist anymore");

                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
