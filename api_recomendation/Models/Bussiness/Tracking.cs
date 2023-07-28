using System.ComponentModel.DataAnnotations;

namespace api_recomendation.Models.Bussiness;

public class Tracking
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string Route { get; set; }

    [Required]
    public string Method { get; set; }

    [Required]

    public DateTime Date { get; set; }

    [Required]
    public string Ip { get; set; }

    [Required]
    public string UserAgent { get; set; }

    [Required]
    public string Query { get; set; }

    [Required]
    public string Body { get; set; }

    [Required]
    public string Response { get; set; }

    [Required]
    public int StatusCode { get; set; }

    [Required]
    public string StatusMessage { get; set; }

    
    
}