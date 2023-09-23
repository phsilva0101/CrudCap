using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CrudCap.WebApi.Filters
{
    public class ModelStateValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid || !context.HttpContext.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                return;
            }

            var validation = context.ModelState.Keys.SelectMany(x => context.ModelState[x].Errors)
                .Select(x => x.ErrorMessage)
                .ToArray();

            var details = new ValidationProblemDetails()
            {
                Instance = context.HttpContext.Request.Path,
                Status = StatusCodes.Status400BadRequest,
                Detail = "Consulte a propriedade de erros para obter detalhes adicionais.",
                Title = "Desafio com as validações"
            };

            details.Errors.Add("DomainValidations", validation);
            context.Result = new BadRequestObjectResult(details) { StatusCode = (int)HttpStatusCode.BadRequest };
        }
    }
}
