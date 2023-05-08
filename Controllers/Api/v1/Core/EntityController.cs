using Microsoft.AspNetCore.Mvc;
using api_recomendation.Services.Core;
using api_recomendation.Models.Core;
using api_recomendation.HttpModels.V1.Core;

namespace api_recomendation.Controllers.Api.V1.Core;


[ApiController]
[Route("api/v1/core/entity")]
public class EntityController : ControllerBase
{
    private readonly IEntityService _entityService;

    public EntityController(IEntityService entityService)
    {
        _entityService = entityService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_entityService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_entityService.GetById(id));
    }

    [HttpPost]
    public IActionResult Add(EntityRequest entity)
    {
        var newEntity = _entityService.Add(entity);
        return Ok(newEntity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id,EntityRequest entity)
    {   

        _entityService.Update(id,entity);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _entityService.Remove(id);
        return Ok(new { message = "Entity removed successfully" });
    }


    [HttpPost("{entityId}/attribute")]
    public IActionResult AddAttribute(int entityId,AttributeEntityRequest attribute)
    {
        var newAttribute = _entityService.Add(entityId,attribute);
        return Ok(newAttribute);
    }

    [HttpPut("{entityId}/attribute/{attributeId}")]
    public IActionResult UpdateAttribute(int entityId,int attributeId,AttributeEntityRequest attribute)
    {   

        _entityService.UpdateAttribute(entityId,attributeId,attribute);
        return Ok();
    }

    
}
