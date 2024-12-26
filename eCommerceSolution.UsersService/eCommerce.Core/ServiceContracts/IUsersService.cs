using eCommerce.Core.Dto;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Contract for users service that contains the cases for users.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case
    /// </summary>
    /// <param name="loginRequest">Reference of <see cref="LoginRequest"/> to represents the user data</param>
    /// <returns>
    /// Returns a <see cref="AuthenticationResponse"/> object that contains status of login
    /// </returns>
    Task<AuthenticationResponse?> Login(LoginRequest? loginRequest);
    
    /// <summary>
    /// Method to handle user register use case
    /// </summary>
    /// <param name="registerRequest">Reference of <see cref="RegisterRequest"/> to represents the user data</param>
    /// <returns>
    /// Returns a <see cref="AuthenticationResponse"/> object that contains status of user registration.
    /// </returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
