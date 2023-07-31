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