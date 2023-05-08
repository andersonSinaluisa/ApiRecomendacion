using Microsoft.EntityFrameworkCore;
using api_recomendation.Models.Auth;
using api_recomendation.Models.Core;

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
    

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // Role
        //crear datos semillas

        //hacer que se ejecute en cada migracion
        
        ICollection<Permission> list = 
        Permission.generatePermissions(new List<string> { "create", "read", "update", "delete" });
        modelBuilder.Entity<Permission>().HasData(list);


        ICollection<Role> roles  = new List<Role>{
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
        
    }
    
}
