using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_recomendation.Models.Auth;
namespace api_recomendation.Models.Core;


public class Profile {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Identifier { get; set; }

    public string? TypeIdentifier { get; set; }

    [ForeignKey("UserId")]
    public int OwnerId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User? Owner { get; set; }
}