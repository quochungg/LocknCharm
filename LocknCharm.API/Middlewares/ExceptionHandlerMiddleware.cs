using LocknCharm.Application.Common;
using Microsoft.AspNetCore.Diagnostics;

namespace LocknCharm.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            int statusCode;
            string message;
            List<string> errors = new();

            switch (exception)
            {
                case UnauthorizedAccessException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    message = "Unauthorized access.";
                    break;

                case KeyNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    message = "Resource not found.";
                    break;

                case ArgumentException argEx:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = "Invalid input.";
                    errors.Add(argEx.Message);
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "An unexpected error occurred.";
                    errors.Add(exception.Message);
                    break;
            }

            var response = APIResponse.Fail(message, errors, statusCode);
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
