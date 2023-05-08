using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Auth;


public class User
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    
    public string? Name { get; set; }
    public string? LastName { get; set; }

    [Required]

    public string? UserName { get; set; }
    [Required]

    public string? Email { get; set; }
    [Required]

    public string? Password { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsStaff { get; set; }

    public bool IsSuperUser { get; set; }

    public bool IsAuthenticated { get; set; }

    
    public DateTime DateJoined { get; set; }

    public DateTime LastLogin { get; set; }

    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    
    public virtual Role? Role { get; set; }

    
}

