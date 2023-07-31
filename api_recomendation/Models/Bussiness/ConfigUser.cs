using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_recomendation.Models.Auth;
namespace api_recomendation.Models.Bussiness
{
    public class ConfigUser
    {
        [Key]
        public int Id { get; set; }

        public string Language { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public string Timezone { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        
        
        
    }
}