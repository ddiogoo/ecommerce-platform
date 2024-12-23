namespace eCommerce.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception type and message
            _logger.LogError("{typeName}: {message}", ex.GetType().ToString(), ex.Message);
            if (ex.InnerException is not null)
            {
                // Log the inner exception type and message
                var innerExceptionType = ex.InnerException.GetType().ToString();
                var innerExceptionMessage = ex.InnerException.Message;
                _logger.LogError("{typeName}: {message}", innerExceptionType, innerExceptionMessage);
            }
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            { 
                ex.Message, Type = ex.GetType().ToString()
            });
        }
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    /// <summary>
    /// Extension method used to add the middleware to the HTTP request pipeline.
    /// </summary>
    /// <param name="builder">Reference to <see cref="IApplicationBuilder"/></param>
    /// <returns>
    /// Returns the reference to <see cref="IApplicationBuilder"/> with all implemented middlewares.
    /// </returns>
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
