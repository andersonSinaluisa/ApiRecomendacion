using api_recomendation.Models.Core;
namespace api_recomendation.HttpModels.V1.Core;


public class AttributeEntityRequest
{

    public string? KeyAttr { get; set; }

    public string? Value { get; set; }

    public double Weight { get; set; }



}