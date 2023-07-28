

namespace api_recomendation.HttpModels.V1.Auth
{
    public class LoginResponse
    {

        
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Token { get; set; }


        public LoginResponse(string username, string email, string? token)
        {
            Username = username;
            Email = email;
            Token = token;
        }


        public LoginResponse()
        {
        }

        

        


    }
}