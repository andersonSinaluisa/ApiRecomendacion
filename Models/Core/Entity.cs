using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_recomendation.Models.Auth;
namespace api_recomendation.Models.Core;



public class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Identifier { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    
    public virtual User? owner { get; set; }
    
    public virtual ICollection<AttributeEntity>? Attributes { get; set; }
}