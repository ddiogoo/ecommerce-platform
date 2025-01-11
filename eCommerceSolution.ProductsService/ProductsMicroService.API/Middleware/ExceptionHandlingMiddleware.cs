namespace ProductsMicroService.API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError("{typeName}: {message}", ex.GetType().ToString(), ex.Message);
            if (ex.InnerException is not null)
            {
                var innerExceptionType = ex.InnerException.GetType().ToString();
                var innerExceptionMessage = ex.InnerException.Message;
                logger.LogError("{typeName}: {message}", innerExceptionType, innerExceptionMessage);
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
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
