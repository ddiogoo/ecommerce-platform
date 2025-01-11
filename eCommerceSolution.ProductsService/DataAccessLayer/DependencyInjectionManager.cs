using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DependencyInjectionManager
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
    {
        return services;
    }
}
