using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api_recomendation.Models.Core
{
    public class AttributeEntityProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("ProfileId")]
        public int ProfileId { get; set; }

        public double Weight { get; set; }
 

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [ForeignKey("AttributeEntityId")]
        public int AttributeEntityId { get; set; }

        public virtual Profile? Profile { get; set; }

        public virtual AttributeEntity? AttributeEntity { get; set; }
    }
}