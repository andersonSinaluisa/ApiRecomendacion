using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api_recomendation.Models.Core
{
    public class Recommendation
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ProfileId")]
        public int ProfileId { get; set; }

        [ForeignKey("EntityId")]
        public int EntityId { get; set; }

        public double Weight { get; set; }

        public bool IsRecommended { get; set; }

        public bool IsAccepted { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Profile Profile { get; set; }
        public Entity Entity { get; set; }
    }
}