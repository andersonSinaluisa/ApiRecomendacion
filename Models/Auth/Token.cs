using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Auth
{
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Value { get; set; }
        
        public DateTime ExpiresAt { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }
    }
}