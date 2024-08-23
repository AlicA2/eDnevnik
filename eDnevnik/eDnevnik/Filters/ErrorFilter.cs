using eDnevnik.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace eDnevnik.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UserException userException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    errors = new
                    {
                        message = userException.Message
                    }
                });
            }
            else
            {
                Console.WriteLine(context.Exception);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(new
                {
                    errors = new
                    {
                        message = "Server side error"
                    }
                });
            }
        }
    }
}
