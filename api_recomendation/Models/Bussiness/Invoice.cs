using System.ComponentModel.DataAnnotations;
  
namespace api_recomendation.Models.Bussiness;


public class Invoice {
    [Key]
    public int Id {get; set;}

    public DateTime Date {get; set;}

    public int UserId {get; set;}

    public decimal Total {get; set;}

    public decimal SubTotal {get; set;}

    public decimal Taxes {get; set;}

    public decimal Discount {get; set;}

    public string? PaymentMethod {get; set;}
}