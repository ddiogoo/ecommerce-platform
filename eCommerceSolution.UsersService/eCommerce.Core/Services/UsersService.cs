using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest? loginRequest)
    {
        if(loginRequest?.Email == null || loginRequest.Password == null) return null;
        var user = await usersRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);
        return user == null ? null : mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest? registerRequest)
    {
        if(registerRequest == null) return null;
        var applicationUser = mapper.Map<ApplicationUser>(registerRequest);
        var user = await usersRepository.AddUserAsync(applicationUser);
        return user == null ? null : mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
    }
}
