namespace api_recomendation.HttpModels.V1.Core;


public class ProfileResponse{
    public int Id { get; set; }

    public string? Identifier { get; set; }

    public string? TypeIdentifier { get; set; }



    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}