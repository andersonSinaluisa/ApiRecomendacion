namespace api_recomendation.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class PermissionRole{
    [Key]
    //AUTOINCREMENT
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int RoleId { get; set; }
    public virtual Role? Role { get; set; }

    public int PermissionId { get; set; }
    public virtual Permission? Permission { get; set; }
}