using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class DependencyInjectionManager
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        return services;
    }
}
