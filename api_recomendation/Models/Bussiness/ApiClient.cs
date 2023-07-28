using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace api_recomendation.Models.Bussiness;


public class ApiClient{

    [Key]
    public int Id {get; set;}
    public string? Name {get; set;}

    public string? Token {get; set;}

    public string? Client {get; set;}

    public bool IsActive {get; set;}

    
    [ForeignKey("UserId")]
    public int UserId {get; set;}

}