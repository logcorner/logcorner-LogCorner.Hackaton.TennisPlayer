using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LogCorner.Hackaton.TennisPlayer.Presentation.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger("ExceptionMiddleware");
                logger.LogError($"Something went wrong: {ex.StackTrace}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var internalServerError = "Internal Server Error.";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (ex is Application.Exceptions.PlayerNotFoundException 
                || ex is Infrastructure.Exceptions.PlayerNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                internalServerError = ex.Message;
            }

            return context.Response.WriteAsync(
                new
                {
                    context.Response.StatusCode,
                    Message =internalServerError
                }.ToString());
        }
    }
}
