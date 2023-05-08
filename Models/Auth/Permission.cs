using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_recomendation.Models.Auth;


public class Permission{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int? Id { get; set; }

    public string? Model { get; set; }

    public string? Action { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Role>? Roles { get; set; }
    

    public static ICollection<Permission> generatePermissions(ICollection<string> actions){
        //obtener los archivos de la carpeta Models

        ICollection<Permission> permissions = new List<Permission>();
        
        //las carpetas estan organizadas Models/Auth/Permission.cs, Models/Core/Entity.cs, Models/Core/AttributeEntity.cs
        string path = Directory.GetCurrentDirectory() + "/Models";


        string[] files = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);
        int i = 1;
        foreach (string file in files)
        {
            
                   
                    //obtener el nombre del archivo
                    string model =  Path.GetFileNameWithoutExtension(file);
                    
                    //crear permisos
                    foreach (string action in actions)
                    {
                        Permission permission =  new Permission();
                        permission.Id = i++;
                        permission.Model = model;
                        permission.Action = action;
                        permission.Description = action + " " + model;
                        permissions.Add(permission);
                    }
                    
                
            
        }
        return permissions;
    }
}