using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjectionManager
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container.
    /// </summary>
    /// <param name="services">Reference of <see cref="IServiceCollection"/></param>
    /// <returns>
    /// Returns a reference of <see cref="IServiceCollection"/> with all implemented services on IoC container.
    /// </returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TO DO: Add services to the IoC container.
        // Infrastructure services often include data access, caching and other low-level components.
        services.AddSingleton<IUsersRepository, UsersRepository>();
        return services;
    }
}
