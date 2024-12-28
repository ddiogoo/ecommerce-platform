using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository) : IUsersService
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<AuthenticationResponse?> Login(LoginRequest? loginRequest)
    {
        if(loginRequest?.Email == null || loginRequest.Password == null) return null;
        var user = await _usersRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);
        return user == null ? null : new AuthenticationResponse(user.UserId, user.Email, user.PersonName, 
            user.Gender, "token", Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest)
    {
        var user = await _usersRepository.AddUserAsync(new ApplicationUser
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString(),
            PersonName = registerRequest.PersonName
        });
        return user == null ? null : new AuthenticationResponse(user.UserId, user.Email, user.Gender, 
            user.PersonName, "token", Success: true);
    }
}
