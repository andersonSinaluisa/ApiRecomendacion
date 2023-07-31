using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api_recomendation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace api_recomendation.Config;
public class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var modifiedEntries = eventData.Context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted)
            .ToList();

        var auditEntries = new List<Audit>();

        foreach (var entry in modifiedEntries)
        {
            var state = GetState(entry);
            
            auditEntries.Add(CreateAuditEntry(entry, state));
            
        }

        // Crear registros de auditoría para las entradas afectadas
        if (auditEntries.Any())
        {
            eventData.Context.Set<Audit>().AddRange(auditEntries);
        }

        return base.SavingChanges(eventData, result);
    }

    // ... El resto del código del interceptor ...

    private State GetState(EntityEntry entry)
    {
        switch (entry.State)
        {
            case EntityState.Added:
                return State.Added;
            case EntityState.Modified:
                return State.Modified;
            case EntityState.Deleted:
                return State.Deleted;
            default:
                return State.Added;
        }
    }

    private Audit CreateAuditEntry(EntityEntry entity, State state)
    {
        var entry = new Audit
        {
            TableName = entity.GetType().Name,
            KeyValues = GetKeyValues(entity),
            OldValues = state == State.Modified ? GetOriginalValues(entity) : null,
            NewValues = state != State.Deleted ? GetModifiedValues(entity) : null,
            Action = state.ToString(),
            ChangedBy = "UsuarioActual", // Reemplazar con la información del usuario actual
            ChangedDate = DateTime.Now
        };

        return entry;
    }

    private string GetKeyValues(object entity)
    {   
        // Obtener la lista de propiedades de clave principal
        var keyProperties = entity.GetType().GetProperties()
            .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(System.ComponentModel.DataAnnotations.KeyAttribute)))
            .ToList();
        
        // Crear un diccionario para almacenar los valores de clave principal
        var keyValues = new Dictionary<string, object>();

        foreach (var property in keyProperties)
        {
            // Obtener el valor de cada propiedad de clave principal
            //ignorar los campos virtuales
            if (property.PropertyType.FullName.Contains("System.Collections.Generic.ICollection") == false
             || property.PropertyType.FullName.Contains("System.Collections.Generic.List") == false 
             || property.PropertyType.FullName.Contains("System.Collections.Generic.IEnumerable") == false)

                keyValues[property.Name] = property.GetValue(entity);
            
        }

        // Convertir el diccionario de valores de clave principal a una cadena JSON
        return JsonConvert.SerializeObject(keyValues);
    }

    private string GetOriginalValues(EntityEntry entity)
    {   
        var modifiedProperties = entity.Properties
            .Where(p => p.IsModified)
            .ToList();
        
        // Crear un diccionario para almacenar los valores modificados
        var newValues = new Dictionary<string, object>();

        foreach (var property in modifiedProperties)
        {
            // Obtener el valor actual de cada propiedad modificada
            newValues[property.Metadata.Name] = property.OriginalValue;
        }

        // Convertir el diccionario de valores modificados a una cadena JSON
        return JsonConvert.SerializeObject(newValues);
    }

    private string GetModifiedValues(EntityEntry entity)
    {
        
        // Obtener la lista de propiedades modificadas
        var modifiedProperties = entity.GetType().GetProperties()
            .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute)) == false)
            .ToList();
        
        // Crear un diccionario para almacenar los valores modificados
        var newValues = new Dictionary<string, object>();

        foreach (var property in modifiedProperties)
        {
            // Obtener el valor actual de cada propiedad modificada
            newValues[property.Name] = property.GetValue(entity);
        }

        // Convertir el diccionario de valores modificados a una cadena JSON
        return JsonConvert.SerializeObject(newValues);
    }
}
