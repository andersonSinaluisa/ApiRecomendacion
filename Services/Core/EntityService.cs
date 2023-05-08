using api_recomendation.Config.DatabaseContext;
using api_recomendation.Models.Core;
using api_recomendation.HttpModels.V1.Core;
namespace api_recomendation.Services.Core;


public class EntityService : IEntityService
{
    private readonly DatabaseContext _context;

    public EntityService(DatabaseContext context)
    {
        _context = context;
    }

    public ICollection<Entity> GetAll()
    {
        return _context.Entities.ToList();
    }

    public Entity GetById(int id)
    {
        return _context.Entities.FirstOrDefault(x => x.Id == id);
    }

    public Entity Add(EntityRequest entity)
    {   
        Entity newEntity = new Entity();
        newEntity.Name = entity.Name;
        newEntity.Description = entity.Description;


        _context.Entities.Add(newEntity);
        _context.SaveChanges();

        if (entity.Attributes != null)
        {
            foreach (var attribute in entity.Attributes)
            {
                AttributeEntity newAttribute = new AttributeEntity();
                newAttribute.KeyAttr = attribute.KeyAttr;
                newAttribute.Value = attribute.Value;
                newAttribute.Weight = attribute.Weight;
                newAttribute.EntityId = newEntity.Id;

                _context.AttributeEntities.Add(newAttribute);
                _context.SaveChanges();
            }
        }

        return newEntity;

    }

    public AttributeEntity Add(int entityId,AttributeEntityRequest attribute)
    {   
        AttributeEntity newAttribute = new AttributeEntity();
        newAttribute.KeyAttr = attribute.KeyAttr;
        newAttribute.Value = attribute.Value;
        newAttribute.Weight = attribute.Weight;
        newAttribute.EntityId = entityId;

        _context.AttributeEntities.Add(newAttribute);
        _context.SaveChanges();

        return newAttribute;

    }

    public AttributeEntity UpdateAttribute(int entityId, int id,AttributeEntityRequest attribute)
    {       


        AttributeEntity attribute_ = _context.AttributeEntities.FirstOrDefault(x => x.Id == id);

        attribute_.KeyAttr = attribute.KeyAttr;
        attribute_.Value = attribute.Value;
        attribute_.Weight = attribute.Weight;
        attribute_.EntityId = entityId;

        _context.AttributeEntities.Update(attribute_);
        _context.SaveChanges();
        return attribute_;
    }

    public void RemoveAttribute(int id)
    {
        var attribute = _context.AttributeEntities.FirstOrDefault(x => x.Id == id);
        _context.AttributeEntities.Remove(attribute);
        _context.SaveChanges();
    }

    public Entity Update(int id,EntityRequest entity)
    {   
        Entity entity_ = _context.Entities.FirstOrDefault(x => x.Id == id);

        entity_.Name = entity.Name;
        entity_.Description = entity.Description;



        _context.Entities.Update(entity_);
        _context.SaveChanges();
        return entity_;
    }

    public void Remove(int id)
    {
        var entity = _context.Entities.FirstOrDefault(x => x.Id == id);
        _context.Entities.Remove(entity);
        _context.SaveChanges();
    }
}


public interface IEntityService
{
    ICollection<Entity> GetAll();
    Entity GetById(int id);
    Entity Add(EntityRequest entity);
    AttributeEntity Add(int entityId,AttributeEntityRequest attribute);

    void RemoveAttribute(int id);

    AttributeEntity UpdateAttribute(int entityId, int id,AttributeEntityRequest attribute);

    Entity Update(int id,EntityRequest entity);
    void Remove(int id);
}
