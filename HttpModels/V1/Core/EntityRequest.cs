using api_recomendation.Models.Core;
namespace api_recomendation.HttpModels.V1.Core
{
    public class EntityRequest 
    {


        public string? Name { get; set; }

        public string? Description { get; set; }


        public ICollection<AttributeEntityRequest>? Attributes { get; set; }
    
        
    }
}