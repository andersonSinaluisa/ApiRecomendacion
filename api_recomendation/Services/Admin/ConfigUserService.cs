using api_recomendation.Config.DatabaseContext;
using api_recomendation.HttpModels.V1.Admin;
using api_recomendation.Models.Bussiness;

namespace api_recomendation.Services.Admin;

public class ConfigUserService : IConfigUserService{

    private readonly DatabaseContext _context;

    public ConfigUserService(DatabaseContext context)
    {
        _context = context;
    }

    public ConfigUserResponse GetConfigUser(int id)
    {
        ConfigUser configUser = _context.ConfigUsers.Where(c => c.UserId == id).FirstOrDefault();
        if (configUser == null)
        {
            return null;
        }
        return new ConfigUserResponse
        {
            Id = configUser.Id,
            Language = configUser.Language,
            Currency = configUser.Currency,
            Country = configUser.Country,
            Timezone = configUser.Timezone
        };
    }

    public ConfigUserResponse CreateConfigUser(ConfigUserRequest configUserRequest)
    {
        ConfigUser configUser = new ConfigUser
        {
            Language = configUserRequest.Language,
            Currency = configUserRequest.Currency,
            Country = configUserRequest.Country,
            Timezone = configUserRequest.Timezone
        };
        _context.ConfigUsers.Add(configUser);
        _context.SaveChanges();
        return new ConfigUserResponse
        {
            Id = configUser.Id,
            Language = configUser.Language,
            Currency = configUser.Currency,
            Country = configUser.Country,
            Timezone = configUser.Timezone
        };
    }

    public ConfigUserResponse UpdateConfigUser(ConfigUserRequest configUserRequest, int userId)
    {
        ConfigUser configUser = _context.ConfigUsers.Where(c => c.UserId == userId).FirstOrDefault();
        if (configUser == null)
        {
            return null;
        }
        configUser.Language = configUserRequest.Language;
        configUser.Currency = configUserRequest.Currency;
        configUser.Country = configUserRequest.Country;
        configUser.Timezone = configUserRequest.Timezone;
        _context.SaveChanges();
        return new ConfigUserResponse
        {
            Id = configUser.Id,
            Language = configUser.Language,
            Currency = configUser.Currency,
            Country = configUser.Country,
            Timezone = configUser.Timezone
        };
    }
    
}

public interface IConfigUserService {

    ConfigUserResponse GetConfigUser(int id);

    ConfigUserResponse CreateConfigUser(ConfigUserRequest configUserRequest);

    ConfigUserResponse UpdateConfigUser(ConfigUserRequest configUserRequest,int userId);


}