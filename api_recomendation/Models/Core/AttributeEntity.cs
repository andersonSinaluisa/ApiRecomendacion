using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Core;

public class AttributeEntity{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    [Required]
    public string? KeyAttr { get; set; }

    public string? Value { get; set; }

    public double Weight { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [ForeignKey("EntityId")]
    public int EntityId { get; set; }

    public virtual Entity? Entity { get; set; }

}