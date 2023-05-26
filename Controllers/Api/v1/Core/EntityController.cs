using Microsoft.AspNetCore.Mvc;
using api_recomendation.Services.Core;
using api_recomendation.Models.Core;
using api_recomendation.HttpModels.V1.Core;
using Microsoft.AspNetCore.Authorization;
using api_recomendation.Services.Auth;
using api_recomendation.HttpModels.V1.Core;

namespace api_recomendation.Controllers.Api.V1.Core;


[ApiController]
[Route("api/v1/core/entity")]
public class EntityController : ControllerBase
{
    private readonly IEntityService _entityService;
    private readonly IUserService _userService;

    public EntityController(IEntityService entityService, IUserService userService)
    {
        _entityService = entityService;
        _userService = userService;
    }

    [Authorize]
    [HttpGet]
    //que este autenticado
    public IActionResult GetAll()
    {
        return Ok(_entityService.GetAll());
    }

    [Authorize]
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        return Ok(_entityService.GetById(id));
    }

    [Authorize]
    [HttpPost]

    public IActionResult Add(EntityRequest entity)
    {
        //get id user from token

        var token = Request.Headers["Authorization"];
        token = token.ToString().Replace("Bearer ", "");
        var userId = _userService.GetUserIdByToken(token);

        var newEntity = _entityService.Add(entity,userId);
        return Ok(new EntityResponse{
            Id = newEntity.Id,
            Name = newEntity.Name,
            Description = newEntity.Description,
            Indentifier = newEntity.Identifier,
            Attributes = newEntity.Attributes.Select(a => new AtrributeEntityResponse{
                Id = a.Id,
                KeyAttr = a.KeyAttr,
                Weight = a.Weight,
                EntityId = a.EntityId,
                Value = a.Value,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList()
        
        });
    }

    [Authorize]
    [HttpPost("many")]
    
    public IActionResult AddMany(List<EntityRequest> entities)
    {   
        var token = Request.Headers["Authorization"];
        token = token.ToString().Replace("Bearer ", "");
        var userId = _userService.GetUserIdByToken(token);
        var list = new List<EntityResponse>();
        foreach(var entity in entities){
            var e = _entityService.Add(entity,userId);
            list.Add(new EntityResponse{
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Indentifier = e.Identifier,
                Attributes = e.Attributes.Select(a => new AtrributeEntityResponse{
                    Id = a.Id,
                    KeyAttr = a.KeyAttr,
                    Weight = a.Weight,
                    EntityId = a.EntityId,
                    Value = a.Value,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                }).ToList()
            });
        }
        return Ok(list);
    }

    [Authorize]
    [HttpPut("{id}")]

    public IActionResult Update(int id,EntityRequest entity)
    {   

        _entityService.Update(id,entity);
        return Ok();
    }


    [Authorize]
    [HttpDelete("{id}")]

    public IActionResult Remove(int id)
    {
        _entityService.Remove(id);
        return Ok(new { message = "Entity removed successfully" });
    }

    [Authorize]
    [HttpPost("{entityId}/attribute")]
    public IActionResult AddAttribute(int entityId,AttributeEntityRequest attribute)
    {
        var newAttribute = _entityService.Add(entityId,attribute);
        return Ok(newAttribute);
    }

    [Authorize]
    [HttpPut("{entityId}/attribute/{attributeId}")]
    public IActionResult UpdateAttribute(int entityId,int attributeId,AttributeEntityRequest attribute)
    {   

        _entityService.UpdateAttribute(entityId,attributeId,attribute);
        return Ok();
    }

    
}
