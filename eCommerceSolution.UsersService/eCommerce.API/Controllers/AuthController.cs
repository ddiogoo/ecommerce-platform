using eCommerce.Core.Dto;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] //api/auth
[ApiController]
public class AuthController(IUsersService usersService) : ControllerBase
{
    [HttpPost("register")] //POST api/auth/register/
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var result = await usersService.Register(registerRequest);
        if(result is not { Success: true }) return BadRequest("Invalid registration data");
        return Ok(result);
    }

    [HttpPost("login")] //POST api/auth/login/
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var result = await usersService.Login(loginRequest);
        if(result is not { Success: true }) return Unauthorized(result);
        return Ok(result);
    }
}
