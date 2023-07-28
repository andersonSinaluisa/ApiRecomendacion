using Microsoft.AspNetCore.Mvc;

namespace api_recomendation.Controllers.Api.V1.Admin;


[ApiController]
[Route("api/v1/admin/[controller]")]
public class Profile : ControllerBase{

    [HttpGet]
    public async Task<IActionResult> Get(){
        return Ok(new {message = "ok"});
    }
    
}