using Microsoft.EntityFrameworkCore;
using api_recomendation.Models.Auth;
using api_recomendation.Models.Core;
using api_recomendation.Models.Bussiness;
using api_recomendation.Models.Core.Bussiness;

namespace api_recomendation.Config.DatabaseContext;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Role>? Roles { get; set; }

    public DbSet<User>? Users { get; set; }

    public DbSet<Permission>? Permissions { get; set; }

    public DbSet<PermissionRole>? PermissionRoles { get; set; }


    public DbSet<AttributeEntity>? AttributeEntities { get; set; }

    public DbSet<Entity>? Entities { get; set; }

    public DbSet<Profile>? Profiles { get; set; }

    public DbSet<ProfileEntity>? ProfileEntities { get; set; }


    public DbSet<Token>? Tokens { get; set; }

    public DbSet<Recommendation>? Recommendations { get; set; }

    public DbSet<AttributeEntityProfile>? AttributeEntityProfiles { get; set; }

    public DbSet<ConfigUser>? ConfigUsers { get; set; }

    public DbSet<Invoice>? Invoices { get; set; }

    public DbSet<Tracking>? Trackings { get; set; }

    public DbSet<Subscription>? Subscriptions { get; set; }

    public DbSet<PaymentMethod>? PaymentMethods { get; set; }

    public DbSet<ApiClient>? ApiClients { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ... Opciones de configuración del DbContext ...

        // Registrar el interceptor de auditoría
        optionsBuilder.AddInterceptors(new AuditInterceptor());
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

            ICollection<Permission> list =
            Permission.generatePermissions();
            modelBuilder.Entity<Permission>().HasData(list);
            ICollection<Role> roles = new List<Role>{
            new Role{
                Id = 1,
                Name = "admin",
                Description = "admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Role{
                Id = 2,
                Name = "user",
                Description = "user",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "demo",
                Email = "demo@mail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("demo"),
                RoleId = 2,
                DateJoined = DateTime.Now,
                IsAdmin = false,
                IsAuthenticated = false,
                IsStaff = false,
                IsSuperUser = false,
                LastLogin = DateTime.Now,
                LastName = "demo",
                UserName = "demo"
            });
        
        



    }

}
