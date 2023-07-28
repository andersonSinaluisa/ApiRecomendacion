using api_recomendation.Config.DatabaseContext;
using api_recomendation.HttpModels.V1.Admin;
using api_recomendation.Models.Bussiness;
using api_recomendation.Services.Auth;

namespace api_recomendation.Services.Admin
{
    public class ApiClientService : IApiClientService
    {
        private readonly IUserService _userService;
        private readonly DatabaseContext _databaseContext;

        public ApiClientService(IUserService userService, DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _userService = userService;
        }

        public async Task<ApiClientResponse> Add(ApiClientRequest apiClientRequest,string token)
        {
            var userId = _userService.GetUserIdByToken(token);
            var clientToken = _userService.GenerateToken(userId);
            var apiClient = new ApiClient
            {
                UserId = userId,
                Name = apiClientRequest.Name,
                Token = clientToken,
                Client = apiClientRequest.Client,
                IsActive = apiClientRequest.IsActive,
            };
            await _databaseContext.ApiClients.AddAsync(apiClient);
            return new ApiClientResponse{
                Id = apiClient.Id,
                Name = apiClient.Name,
                Client = apiClient.Client,
                IsActive = apiClient.IsActive,
                Token = apiClient.Token
            
            };
        }

        public async Task<List<ApiClientResponse>> GetByToken(string token)
        {
            var idUser = _userService.GetUserIdByToken(token);
            
            var tokens =  _databaseContext.ApiClients.Where(x => x.UserId == idUser).ToList();

            return tokens.Select(x => new ApiClientResponse{
                Id = x.Id,
                Name = x.Name,
                Client = x.Client,
                IsActive = x.IsActive,
                Token = x.Token
            }).ToList();

        }
        public async Task Delete(int id)
        {
            var apiClient = await _databaseContext.ApiClients.FindAsync(id);
            _databaseContext.ApiClients.Remove(apiClient);
            await _databaseContext.SaveChangesAsync();
        }

      
    }

    public interface IApiClientService
    {
        Task<ApiClientResponse> Add(ApiClientRequest apiClientRequest,string token);
        Task<List<ApiClientResponse>> GetByToken(string token);
        Task Delete(int id);
    }
}