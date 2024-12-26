using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjectionManager
{
    /// <summary>
    /// Extension method to add core services to the dependency injection container.
    /// </summary>
    /// <param name="services">Reference of <see cref="IServiceCollection"/></param>
    /// <returns>
    /// Returns a reference of <see cref="IServiceCollection"/> with all implemented services on IoC container.
    /// </returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container.
        // Core services often include Data Transfer Objects (Dto), Business Logic Services, Business Logic Interfaces
        // and others components.
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
