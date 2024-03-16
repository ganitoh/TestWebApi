using System.Net;
using TestWebApi.Domain.Exceptions;

namespace TestWebApi.WebUI.Middleware
{
    public class ExceptionHandlerMIddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMIddleware> _logger;

        public ExceptionHandlerMIddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMIddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundEntityException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandlerNotFoundEntityExceptionAsync(ex, context);
            }
            catch (PasswordInccorectException ex)
            {
                await HandlerPasswordInccorectExceptionAsync(ex, context);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                await HandlerExceptionAsync(ex,context);
            }
        }

        private async Task HandlerNotFoundEntityExceptionAsync(NotFoundEntityException ex, HttpContext context)
        {
            var code = HttpStatusCode.BadRequest;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }

        public async Task HandlerExceptionAsync(Exception ex,HttpContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task HandlerPasswordInccorectExceptionAsync(PasswordInccorectException ex, HttpContext context)
        {
            var code = HttpStatusCode.BadRequest;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
