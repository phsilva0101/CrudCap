using CrudCap.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CrudCap.WebApi.Filters
{
    public class DomainValidationFilter : IAsyncResultFilter
    {
        private readonly IDomainValidationService _domainValidationService;

        public DomainValidationFilter(IDomainValidationService domainValidationService)
        {
            _domainValidationService = domainValidationService;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_domainValidationService.Return == Domain.Enums.ReturnHttp.NotFound)
            {
                ValidationProblemDetails details = new()
                {
                    Instance = context.HttpContext.Request.Path,
                    Detail = "NotFoundException",
                    Title = "Não Encontrado",
                    Status = StatusCodes.Status404NotFound
                };

                context.Result = new NotFoundObjectResult(details);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (_domainValidationService.Return == Domain.Enums.ReturnHttp.BadRequest)
            {
                ValidationProblemDetails details = new()
                {
                    Instance = context.HttpContext.Request.Path,
                    Detail = "Consulte a propriedade de erros para obter detalhes adicionais.",
                    Title = "Validação Aplicada"
                };

                details.Errors.Add("DomainValidations", _domainValidationService.Messages);
                context.HttpContext.Response.ContentType = "application/json";

                context.Result = new BadRequestObjectResult(details);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            await next();
        }
    }
}
