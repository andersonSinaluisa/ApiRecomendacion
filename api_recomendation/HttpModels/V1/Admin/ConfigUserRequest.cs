namespace api_recomendation.HttpModels.V1.Admin;

public class ConfigUserRequest
{
    public string Language { get; set; }

    public string Currency { get; set; }

    public string Country { get; set; }

    public string Timezone { get; set; }

}