namespace api_recomendation.HttpModels.V1.Auth
{
    public class PasswordConfirm{
        public string? Password { get; set; }
        public string? PasswordRepeat { get; set; }

        public string? Token { get; set; }

        public string? Email { get; set; }

        
    }
}