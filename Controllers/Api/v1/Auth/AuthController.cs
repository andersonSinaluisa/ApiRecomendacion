using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api_recomendation.Services.Auth;
using api_recomendation.HttpModels.V1.Auth;

namespace api_recomendation.Controllers.Api.V1.Auth;


[Route("api/v1/auth")]
public class AuthController : ControllerBase{


    private readonly IUserService _authRepository;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService authRepository,IConfiguration configuration){
        _authRepository = authRepository;
        _configuration = configuration;
    }

    //<summary>
    //login
    //</summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest){
        
        var user = _authRepository.GetByEmaiAndPassword(loginRequest.Email, loginRequest.Password);
        if(user == null){
            return BadRequest(new {message = "Username or password is incorrect"});
        }


        string stringToken = _authRepository.GenerateToken(user.Id);

        _authRepository.CreateToken(user.Id, stringToken, DateTime.UtcNow.AddDays(7));
        

        return Ok(new LoginResponse(user.UserName, user.Email, stringToken));
        
    }


    //registro
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest){

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user= _authRepository.Create(registerRequest);
        

        return Ok(new RegisterResponse(user));
    }


}