//create a middleware
using System;
using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;


using api_recomendation.Config.DatabaseContext;

using api_recomendation.Models.Auth;
using api_recomendation.Services.Auth;

namespace api_recomendation.Middlewares
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DatabaseContext _context;

        private readonly IUserService _userService;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, DatabaseContext _context, IUserService _userService)
        {
            var endpoint = context.Request.Path.Value;
            var method = context.Request.Method;
            var action =  "Index";
            var controller ="Home";

            /*var permission = await _context.Permissions
                .Where(p => p.Endpoint == controller && p.Action == action && p.Method == method)
                .FirstOrDefaultAsync();

            if (permission != null)
            {
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var iduser =  _userService.GetUserIdByToken(token);
                var user = await _context.Users
                    .Where(u => u.Id == iduser)
                    .FirstOrDefaultAsync();
                if (user != null)
                {
                    var role = user.Role;
                    var hasPermission = await _context.PermissionRoles
                        .Where(pr => pr.RoleId == role.Id && pr.PermissionId == permission.Id)
                        .AnyAsync();

                    if (hasPermission)
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("Forbidden");
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                }
            }
            else
            {
                await _next(context);
            }*/
            await _next(context);
        }
    }
}