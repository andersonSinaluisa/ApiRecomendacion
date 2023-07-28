using api_recomendation.Config.DatabaseContext;
using api_recomendation.Models.Auth;
using api_recomendation.HttpModels.V1.Auth;
using System.Security.Cryptography;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace api_recomendation.Services.Auth;


public class UserService: IUserService{

    DatabaseContext _context;
    IConfiguration _configuration;

    public UserService(DatabaseContext context, IConfiguration configuration){
        _context = context;
        _configuration = configuration;
    }

    public User Create(RegisterRequest user){


        Role role = _context.Roles.Where(r => r.Name == "user").FirstOrDefault();

        string passwordHasher = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = passwordHasher;

        User _user = new User{
            Name = user.Name,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            IsAdmin = false,
            IsStaff = false,
            IsSuperUser = false,
            IsAuthenticated = false,
            DateJoined = DateTime.Now,
            LastLogin = DateTime.Now,
            RoleId = role.Id
        };


        //asignar rol

        _context.Users.Add(_user);
        _context.SaveChanges();
        return _user;
    }

    public void Update(int id, User user){
        var userToUpdate = _context.Users.Find(id);
        userToUpdate.Name = user.Name;
        userToUpdate.LastName = user.LastName;
        userToUpdate.UserName = user.UserName;
        userToUpdate.Email = user.Email;
        userToUpdate.Password = user.Password;
        userToUpdate.IsAdmin = user.IsAdmin;
        userToUpdate.IsStaff = user.IsStaff;
        userToUpdate.IsSuperUser = user.IsSuperUser;
        userToUpdate.IsAuthenticated = user.IsAuthenticated;
        userToUpdate.DateJoined = user.DateJoined;
        userToUpdate.LastLogin = user.LastLogin;
        userToUpdate.RoleId = user.RoleId;
        _context.SaveChanges();
    }

    public void Delete(int id){
        var userToDelete = _context.Users.Find(id);
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
    }

    public User GetById(int id){
        return _context.Users.Find(id);
    }

    public User GetByUserNameAndPassword(string userName, string password){
        return _context.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
    }

    public User GetByEmaiAndPassword(string email, string password){
        User _user = _context.Users.Where(u => u.Email == email).FirstOrDefault();

        bool _password = BCrypt.Net.BCrypt.Verify(password, _user.Password);
        if (!_password){
            return null;
        }
        return _user;
    }

    public void UpdateToken(int userId, string token,DateTime expiresAt){
        var userToUpdate = _context.Tokens. Where(t => t.UserId == userId).FirstOrDefault();
        userToUpdate.Value = token;
        userToUpdate.ExpiresAt = expiresAt;
        _context.SaveChanges();
    }

    public void CreateToken(int userId, string token,DateTime expiresAt){
        if (_context.Tokens.Where(t => t.UserId == userId).FirstOrDefault() != null){
            UpdateToken(userId, token, expiresAt);
            return;
        }
        Token _token = new Token{
            Value = token,
            ExpiresAt = expiresAt,
            UserId = userId
        };
        _context.Tokens.Add(_token);
        _context.SaveChanges();
    }

    public int GetUserIdByToken(string token){

        //getclaims
        var key = _configuration.GetValue<string>("SecretJwt");
        var keyBytes = Encoding.ASCII.GetBytes(key);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenConfig = tokenHandler.ReadJwtToken(token);
        var _token = tokenConfig.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
        

        return int.Parse(_token.Value);
    }
    
    public string GenerateToken(int userid){
        var key = _configuration.GetValue<string>("SecretJwt");
        var keyBytes = Encoding.ASCII.GetBytes(key);

        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userid+""));

        var credentialsToken = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                                                      SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = claims,
            Expires = DateTime.MaxValue,
            SigningCredentials = credentialsToken
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
        string stringToken = tokenHandler.WriteToken(tokenConfig);
        return stringToken;
    }
        
}


public interface IUserService{
    User Create(RegisterRequest user);
    void Update(int id, User user);
    void Delete(int id);
    User GetById(int id);
    User GetByUserNameAndPassword(string userName, string password);

    User GetByEmaiAndPassword(string email, string password);

    void UpdateToken(int userId, string token,DateTime expiresAt);

    void CreateToken(int userId, string token,DateTime expiresAt);
    string GenerateToken(int userid);
    int GetUserIdByToken(string token);
}