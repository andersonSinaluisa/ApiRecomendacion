namespace api_recomendation.HttpModels.V1.Admin
{
    public class ApiClientResponse
    {
        public int Id {get; set;}
        public string? Name {get; set;}

        public string? Client {get; set;}

        public bool IsActive {get; set;}

        public string Token {get; set;}

    }
}