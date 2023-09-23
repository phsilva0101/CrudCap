using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudCap.WebApi.Filters
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails
            {
                Title = "Erro Interno no Servidor.",
                Status = StatusCodes.Status500InternalServerError,
                Detail = context.Exception.StackTrace,
                Instance = context.HttpContext.Request.Path
            };

            details.Errors.Add("ServerError", new string[] { "Atualize a página e tente novamente." });

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
