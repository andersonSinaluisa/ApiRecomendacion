using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api_recomendation.Services.Core;
public class ControllerInfo
{
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string HttpMethod { get; set; }

    public static List<ControllerInfo> GetAllControllersAndMethods()
    {
        var controllerMethods = new List<ControllerInfo>();

        var controllers = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type) && !type.IsAbstract);

        foreach (var controllerType in controllers)
        {
            var controllerName = controllerType.Name;
            var methods = controllerType.GetMethods()
                .Where(method => method.IsPublic && !method.IsSpecialName && method.DeclaringType == controllerType);

            foreach (var method in methods)
            {
                var httpMethod = GetHttpMethodForAction(method);
                var actionName = method.Name;
                var controllerMethodInfo = new ControllerInfo
                {
                    ControllerName = controllerName,
                    ActionName = actionName,
                    HttpMethod = httpMethod
                };
                controllerMethods.Add(controllerMethodInfo);
            }
        }

        return controllerMethods;
    }

    private static string GetHttpMethodForAction(MethodInfo method)
    {
        var httpAttributes = method.GetCustomAttributes(true)
        .Where(attr => attr is HttpMethodAttribute)
        .Select(attr => attr as HttpMethodAttribute);

        if (httpAttributes.Any())
        {
            return httpAttributes.First().HttpMethods.First();
        }

        // Por defecto, si no se encuentra ningún verbo HTTP específico, se asume POST.
        return "POST";
    }
}

// Obtener todos los controladores y sus métodos
