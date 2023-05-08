using System.ComponentModel.DataAnnotations;

namespace api_recomendation.HttpModels.V1.Auth;

public class RegisterRequest{

    [Required(ErrorMessage = "Nombre requerido")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Apellido requerido")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Nombre de usuario requerido")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Correo requerido")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Contraseña requerida")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    [MaxLength(16, ErrorMessage = "La contraseña debe tener menos de 16 caracteres")]
    
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirmación de contraseña requerida")]
    public string? PasswordConfirm { get; set; }
}