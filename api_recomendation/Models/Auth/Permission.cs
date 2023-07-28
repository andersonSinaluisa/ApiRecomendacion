using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using api_recomendation.Services.Core;

namespace api_recomendation.Models.Auth;


public class Permission{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int? Id { get; set; }

    public string? Endpoint { get; set; }

    public string? Action { get; set; }

    public string? Method { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Role>? Roles { get; set; }
    

    public static ICollection<Permission> generatePermissions(){
        //obtener los archivos de la carpeta Models

        var permissions = new List<Permission>();
        var data = ControllerInfo.GetAllControllersAndMethods();
        var i = 0;
        foreach (ControllerInfo file in data)
        {
            
                Permission permission =  new Permission();
                permission.Id = i++;
                permission.Endpoint = file.ControllerName;
                permission.Action = file.ActionName;
                permission.Method = file.HttpMethod;
                permissions.Add(permission);
            
        }
        return permissions;
    }
}