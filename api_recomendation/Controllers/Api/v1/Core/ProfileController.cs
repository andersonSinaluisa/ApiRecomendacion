using Microsoft.AspNetCore.Mvc;
using api_recomendation.Services.Core;
using api_recomendation.Models.Core;
using System.IdentityModel.Tokens.Jwt;
using api_recomendation.HttpModels.V1.Core;
using Microsoft.AspNetCore.Authorization;
using api_recomendation.Services.Auth;
namespace api_recomendation.Controllers.Api.V1.Core;


[ApiController]
[Route("api/v1/profile")]
public class ProfileController : ControllerBase{

    private readonly IRecomendationService _recomendationService;
    private readonly IProfileService _profileService;

    private readonly IUserService _userService;

    public ProfileController(IRecomendationService recomendationService, IProfileService profileService, IUserService userService)
    {
        _recomendationService = recomendationService;
        _profileService = profileService;
        _userService = userService;

    }

    [HttpPost]
    [Authorize]
    public IActionResult Save(ProfileRequest r){
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        token = token.ToString().Replace("Bearer ", "");
        var userId = _userService.GetUserIdByToken(token);

        //to int 
        
        var result = _profileService.Add(r,userId);
        return Ok(result);
    }


    [HttpGet("{id}")]
    [Authorize]

    public IActionResult Update(int id,ProfileRequest r){
        var result = _profileService.Update(id,r);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize]

    public IActionResult Delete(int id){
        _profileService.Delete(id);
        return Ok();
    }


    [HttpGet("{profileId}/train")]
    [Authorize]

    public ActionResult<ICollection<AtrributeEntityResponse>> Train(int profileId)
    {   
        //obtener el usuario logueado
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        token = token.ToString().Replace("Bearer ", "");
        var userId = _userService.GetUserIdByToken(token);


        var result = _recomendationService.Train(profileId,userId);
        return Ok(result);
    }


    [HttpGet("{profileId}/recomendation")]
    [Authorize]
    public ActionResult<ICollection<EntityResponse>> GetRecomendation(int profileId)
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        token = token.ToString().Replace("Bearer ", "");
        var userId = _userService.GetUserIdByToken(token);

        //to int 
        var result = _recomendationService.GetRecomendations(profileId,userId);
        return Ok(result);
    }


    [HttpPost("{profileId}/recomendation")]
    [Authorize]

    public IActionResult Save(RecommendationRequest r){
        _recomendationService.Save(r);
        return Ok();
    }

    [HttpPost("{profileId}/recomendation/many")]
    [Authorize]
    public IActionResult SaveMany(List<RecommendationRequest> r){
        foreach (var item in r)
        {
            _recomendationService.Save(item);
        }
        return Ok();
    }


    [HttpDelete("{profileId}/recomendation")]
    [Authorize]

    public IActionResult DeleteAll(int profileId)
    {
        _recomendationService.DeleteAll(profileId);
        return Ok();
    }

    [HttpPut("{profileId}/recomendation/{id}")]
    [Authorize]

    public IActionResult Update(int id, RecommendationRequest r){
        var result = _recomendationService.Update(id,r);
        return Ok(result);
    }
}