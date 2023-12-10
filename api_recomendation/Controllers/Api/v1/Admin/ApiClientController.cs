using api_recomendation.HttpModels.V1.Admin;
using api_recomendation.Services.Admin;
using api_recomendation.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_recomendation.Controllers.Api.V1.Admin;


[ApiController]
[Route("api/v1/admin/[controller]")]
[Authorize]	
public class ApiClientController: ControllerBase {

    private readonly IApiClientService _apiClientService;

    public ApiClientController(IApiClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    
    [HttpPost]
    /// <summary>
    /// The function takes an API client request, extracts the authorization token from the request
    /// headers, and calls the Add method of the API client service with the request and token,
    /// returning the response.
    /// </summary>
    /// <param name="ApiClientRequest">The `ApiClientRequest` parameter is an object that contains the
    /// data needed to make the API request. It likely includes properties such as the request method
    /// (e.g., GET, POST, PUT, DELETE), the endpoint URL, and any request headers or body data.</param>
    /// <returns>
    /// The method is returning an IActionResult object, specifically an Ok response with the response
    /// object as the content.
    /// </returns>
    public IActionResult Add(ApiClientRequest apiClientRequest){
        var token = Request.Headers["Authorization"];
        token = token.ToString().Replace("Bearer ", "");
        var response = _apiClientService.Add(apiClientRequest,token);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetByToken(){
        var token = Request.Headers["Authorization"];
        token = token.ToString().Replace("Bearer ", "");
        var response = _apiClientService.GetByToken(token);
        return Ok(response);
    }

}