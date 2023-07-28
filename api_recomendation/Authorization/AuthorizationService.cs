using api_recomendation.Config.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace api_recomendation.Authorization;
public interface IAuthorizationService
{
    Task<bool> IsSuperAdmin(string username);
    
    Task<bool> IsAdmin(string username);
}

public class AuthorizationService : IAuthorizationService
{
    private readonly DatabaseContext _dbContext;

    public AuthorizationService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsSuperAdmin(string username)
    {
        var user = await _dbContext.Users
            .Include(u => u.Role)
            .ThenInclude(r => r.Permissions)
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            return false;
        }


        return user.IsSuperUser;
    }

    public async Task<bool> IsAdmin(string username)
    {
        var user = await _dbContext.Users
            .Include(u => u.Role)
            .ThenInclude(r => r.Permissions)
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            return false;
        }

        return user.IsAdmin;
    }
    
}
