using System.ComponentModel.DataAnnotations;

namespace api_recomendation.HttpModels.V1.Auth;


public class LoginRequest {

    [Required(ErrorMessage = "Correo requerido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Contraseña requerida")]
    public string? Password { get; set; }

}