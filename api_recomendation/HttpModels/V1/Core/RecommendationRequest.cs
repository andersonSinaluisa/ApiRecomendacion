using System.ComponentModel.DataAnnotations;

namespace api_recomendation.HttpModels.V1.Core
{
    public class RecommendationRequest
    {
        [Required(ErrorMessage = "Perfil requerido")]
        public int ProfileId { get; set; }

        [Required(ErrorMessage = "Entidad requerida")]
        public int EntityId { get; set; }

        [Required(ErrorMessage = "Prioridad requerida requerido")]
        [Range(0,10, ErrorMessage = "La prioridad debe estar entre 0 y 10")]
        public double Weight { get; set; }


        public bool IsRecommended { get; set; }

        public bool IsAccepted { get; set; }
    }
}