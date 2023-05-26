namespace api_recomendation.HttpModels.V1.Core;


public class RecommendationResponse{
    public int ProfileId { get; set; }
    public int EntityId { get; set; }
    public double Weight { get; set; }
    public bool IsRecommended { get; set; }
    public bool IsAccepted { get; set; }
}