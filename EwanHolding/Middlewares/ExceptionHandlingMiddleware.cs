using EwanHolding.Application.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EwanHolding.Api.Middlewares
{
    /// <summary>
    /// Catches every unhandled exception in one place and turns it into a
    /// consistent JSON shape: { statusCode, message, errors }.
    /// - AppException subclasses (NotFoundException, ConflictException, ...) -> their own status code.
    /// - FluentValidation.ValidationException -> 400 with a field/message list.
    /// - Anything else -> 500, with the real message hidden outside Development
    ///   (so we never leak stack traces / internal details to the frontend or the public).
    /// Must be the first middleware registered so it wraps everything after it.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception ex)
        {
            var (statusCode, message, errors) = Map(ex);

            if (statusCode == HttpStatusCode.InternalServerError)
                _logger.LogError(ex, "Unhandled exception on {Method} {Path}", context.Request.Method, context.Request.Path);
            else
                _logger.LogWarning(ex, "Handled exception on {Method} {Path}: {Message}", context.Request.Method, context.Request.Path, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var payload = new
            {
                statusCode = (int)statusCode,
                message,
                errors
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }

        private (HttpStatusCode StatusCode, string Message, object? Errors) Map(Exception ex)
        {
            switch (ex)
            {
                case AppException appEx:
                    return (appEx.StatusCode, appEx.Message, null);

                case ValidationException validationEx:
                    var errors = validationEx.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                    return (HttpStatusCode.BadRequest, "One or more validation errors occurred.", errors);

                case UnauthorizedAccessException:
                    return (HttpStatusCode.Unauthorized, "You are not authorized to perform this action.", null);

                default:
                    // Never leak internal exception details/stack traces outside Development.
                    var message = _env.IsDevelopment() ? ex.Message : "An unexpected error occurred. Please try again later.";
                    return (HttpStatusCode.InternalServerError, message, null);
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
