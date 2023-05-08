using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Auth;


public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }


    [Required]
    
    public string? Name { get; set; }
    public string? Description { get; set; }

    //hacer que se agree la fecha de creacion y actualizacion
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<User>? Users { get; set; }

    public virtual ICollection<Permission>? Permissions { get; set; }
}