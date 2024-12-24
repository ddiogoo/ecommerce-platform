using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract tp be implemented by UsersRepository that contains data access logic of Users data store.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a user to the data store.
    /// </summary>
    /// <param name="user">Represents a user on real world</param>
    /// <returns>Return a reference of added user.</returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
    
    /// <summary>
    /// Method to retrieve existing user by their email and passoword.
    /// </summary>
    /// <param name="email">User email</param>
    /// <param name="password">User password</param>
    /// <returns>Return the reference of found user.</returns>
    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password);
}
