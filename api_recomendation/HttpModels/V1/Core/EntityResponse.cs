using api_recomendation.Models.Core;
namespace api_recomendation.HttpModels.V1.Core
{
    public class EntityResponse
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Indentifier { get; set; }

        public ICollection<AtrributeEntityResponse>? Attributes { get; set; }
    
    }
}