using api_recomendation.Models.Core;
namespace api_recomendation.HttpModels.V1.Core;

public class AtrributeEntityResponse
{


    public int Id { get; set; }

    public string? KeyAttr { get; set; }

    public string? Value { get; set; }

    public double Weight { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int EntityId { get; set; }

}