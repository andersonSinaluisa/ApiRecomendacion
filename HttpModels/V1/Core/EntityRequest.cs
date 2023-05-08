using api_recomendation.Models.Core;
using System.ComponentModel.DataAnnotations;

namespace api_recomendation.HttpModels.V1.Core
{
    public class EntityRequest 
    {

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Descripción requerida")]
        public string? Description { get; set; }


        public ICollection<AttributeEntityRequest>? Attributes { get; set; }
    
        
    }
}