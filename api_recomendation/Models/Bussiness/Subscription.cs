using System.ComponentModel.DataAnnotations;

namespace api_recomendation.Models.Core.Bussiness;


public class Subscription {

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public int MaxUsers { get; set; }

    [Required]
    public int MaxEntities{ get; set; }

    [Required]
    public int MaxProfiles { get; set; }


    [Required]
    public int MaxRequests { get; set; }

    [Required]
    public int MaxRecommendations { get; set; }

    

}