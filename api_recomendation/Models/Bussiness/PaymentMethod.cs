using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Bussiness
{


    public enum PaymentMethodEnum
    {
        Cash,
        CreditCard,
        DebitCard,
        Check,
        Transfer,
        Deposit,
        Other
    }
    public class PaymentMethod
    {
        [Key]
        public int Id {get; set;}
        public string? Name {get; set;}

        public string? Description {get; set;}

        public bool IsActive {get; set;}

        public PaymentMethodEnum Type {get; set;}

        
        [ForeignKey("UserId")]
        public int UserId {get; set;}

      
    }
}