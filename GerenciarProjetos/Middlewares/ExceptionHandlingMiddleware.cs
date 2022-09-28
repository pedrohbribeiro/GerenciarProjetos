using GerenciarProjetos.Exceptions;
using GerenciarProjetos.Models;
using GerenciarProjetos.Models.Responses;
using System.Net;
using System.Text.Json;

namespace GerenciarProjetos.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ErrorResponse errorResponse = new();

            if(exception is FluentValidation.ValidationException exceptionFluentValidation)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var fluentValidationResult = TratarExcecaoFluentValidation(exceptionFluentValidation);
                await context.Response.WriteAsync(fluentValidationResult);
                return;
            }

            if (exception is not BaseException)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.TextoResposta = "Ocorreu um erro inesperado, tente novamente. Caso o problema persista, entre em contato com o suporte.";
                var unknownResult = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(unknownResult);
                return;
            }

            var systemException = exception as BaseException;
            response.StatusCode = (int)systemException.StatusCode;
            errorResponse.TextoResposta = exception.Message;
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }

        private string TratarExcecaoFluentValidation(FluentValidation.ValidationException exception)
        {
            var response = new BadRequestResponse()
            {
                TextoResposta = "Uma ou mais propriedades possuem valores inválidos",
                Errors = exception.Errors?.Select(k => new ErrorsValidation()
                {
                    Erro = k.ErrorMessage,
                    Property = k.PropertyName
                }).ToList()
            };

            return JsonSerializer.Serialize(response);
        }
    }
}
