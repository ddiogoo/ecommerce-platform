using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        // Generate a new unique user ID for the user
        user.UserId = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Person name",
            Gender = EnumGender.Male.ToString()
        };
    }
}
