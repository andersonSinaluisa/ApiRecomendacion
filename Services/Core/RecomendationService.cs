using api_recomendation.Models.Core;
using api_recomendation.HttpModels.V1.Core;
using api_recomendation.Config.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace api_recomendation.Services.Core;

public class RecomendationService : IRecomendationService{

    private readonly DatabaseContext _context;
    private readonly ILogger<RecomendationService> _logger;

    public RecomendationService(DatabaseContext context, ILogger<RecomendationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public ICollection<AtrributeEntityResponse> Train(int profileId,int OwnerId)
    {   
        
        _logger.LogInformation("Iniciando entrenamiento del perfil: " + profileId);

        //Obtener las recomendaciones aceptadas del perfil
        Array recomendations = _context.Recommendations.Where(r => r.ProfileId == profileId ).Include(
            r => r.Entity
        ).ToArray();

        
        
        //Obtener los atributos de la entidades a recomendar
        var attrs = _context.AttributeEntities
        .Where(a => a.Entity.UserId == OwnerId )
        .Include(a => a.Entity)
        .ToList()
        .DistinctBy(a => a.Value);

        //crear matriz de encodings para las entidades ya recomendadas
        var matrizEncodings = new List<List<double>>();

        //crear vector de encodings para las entidades ya recomendadas y calificadas    
        var vectorEncodings = new List<double>();

        _logger.LogInformation("Iniciando entrenamiento del perfil: " + profileId);
        //recorrer las recomendaciones
        foreach (Recommendation recomendation in recomendations)
        {
            

                //agregar la puntacion de la recomendacion al vector de encodings
                vectorEncodings.Add(recomendation.Weight);


                //crear una fila para la matriz de encodings
                var row = new List<double>();

                //recorrer los atributos de la entidad a recomendar
                foreach (var attr in attrs)
                {
                    //si el atributo de la entidad a recomendar esta en los atributos de la recomendacion
                    _logger.LogInformation("Atributo: "+attr.KeyAttr+" Recomendacion: "+recomendation.Entity.Description);
                Entity entity = recomendation.Entity;
                ICollection<AttributeEntity>? attributes = entity.Attributes;
                IEnumerable<string?> enumerable = attributes?.Select(a => a.Value) ?? new List<string?>();
                if (enumerable
                    .Contains(attr.Value))
                    {
                        //agregar 1 a la fila
                        row.Add(1);
                    }
                    else
                    {
                        //agregar 0 a la fila
                        row.Add(0);
                    }
                    
                    
                }


                //agregar la fila a la matriz de encodings
                matrizEncodings.Add(row);


        }

        //print to console matrizEncodings

        _logger.LogInformation("Matriz de encodings: " + matrizEncodings[0].Count+" "+vectorEncodings.Count);


        //print to console matrizEncodings
        

        //crear matriz de encodings para las entidades a recomendar

        //vectorEncodings = [0.5,0.2,0.3]
        //matrizEncodings = [
        //    [1,0,1]
        //    [0,1,1],
        //    [1,1,0]
        //]
        var resultMultiplication = new List<List<double>>();
        
        //multiplicar vector por matriz
        foreach (var row in matrizEncodings)
        {
            var resultRow = new List<double>();
            for (int i = 0; i < row.Count; i++)
            {
                if(i > vectorEncodings.Count){
                    break;
                }
                _logger.LogInformation("Multiplicando: " + row[i] + " * " + vectorEncodings[i]);
                resultRow.Add(row[i] * vectorEncodings[i]);
            }
            resultMultiplication.Add(resultRow);
        }
         

        var vectorSum = new List<double>();
        //sumar columnas
        /*
            [
                [0,2,2,0],
                [10,10,10,10],
                [8,0,8,8]
            ]

        */
        if(resultMultiplication.Count == 0){
            return new List<AtrributeEntityResponse>();
        }
        // Obtener la cantidad de columnas de la matriz
        int columnCount = resultMultiplication[0].Count;

        _logger.LogInformation("Cantidad de columnas: " + columnCount);

        // Crear una lista para almacenar los resultados de la suma de cada columna
        List<double> columnSums = new List<double>();

        // Recorrer las columnas de la matriz
        for (int col = 0; col < columnCount; col++)
        {
            double sum = 0;

            // Recorrer los elementos de la columna actual y sumar sus valores
            for (int row = 0; row < resultMultiplication.Count; row++)
            {
                sum += resultMultiplication[row][col];
            }

            // normalizar
            columnSums.Add(sum);
        }

        _logger.LogInformation("Suma de columnas: " + columnSums.Count);
        

        // Calcular el valor mínimo y máximo


        // Normalizar los valores
        List<double> normalizedResults = new List<double>();
        
    

        for(int i = 0; i < columnSums.Count; i++){
            var result = columnSums[i];
            double normalizedResult = result / columnSums.Sum();
            normalizedResults.Add(normalizedResult);

            var attrId = attrs.Select(a => a.Id).ToList()[i];

            var attrProfile = _context.AttributeEntityProfiles.Where(a => a.ProfileId == profileId && a.AttributeEntityId == attrId).FirstOrDefault();
            if (attrProfile != null)
            {
                attrProfile.Weight = normalizedResult;
                attrProfile.UpdatedAt = DateTime.Now;
            }
            else
            {
                attrProfile = new AttributeEntityProfile{
                    AttributeEntityId = attrId,
                    ProfileId = profileId,
                    Weight = normalizedResult,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.AttributeEntityProfiles?.Add(attrProfile);
            }


        }

        _context.SaveChanges();

        ICollection<AttributeEntityProfile> profiletraint = _context.AttributeEntityProfiles.Where(a => a.ProfileId == profileId).ToList();

        ICollection<AtrributeEntityResponse> atrributeEntityResponses = new List<AtrributeEntityResponse>();
        profiletraint.ToList().ForEach(a => {
            atrributeEntityResponses.Add(new AtrributeEntityResponse{
                Id = a.Id,
                KeyAttr = a.AttributeEntity.KeyAttr,
                EntityId = a.AttributeEntity.EntityId,
                Weight = a.Weight,
                Value   = a.AttributeEntity.Value,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            });
        });

        return atrributeEntityResponses;
    }

    public ICollection<EntityResponse> GetRecomendations(int profileId,int OwnerId){

        var profileList = _context.AttributeEntityProfiles.Where(a => a.ProfileId == profileId).ToList();
        var recomendations = _context.Recommendations.Where(r => r.ProfileId == profileId && !r.IsAccepted).ToList();


        
        ICollection<Entity> entities = _context.Entities.Where(e => e.UserId == OwnerId).ToList();
        var attrs = _context.AttributeEntities
        .Where(a => a.Entity.UserId == OwnerId )
        .Include(a => a.Entity)
        .ToList()
        .DistinctBy(a => a.Value);

        var result = new List<Recommendation>();
        var entities_copy = new List<Entity>();
        var matrizEncodings = new List<List<double>>();

        foreach(var entity in entities){

            if(recomendations.Where(r => r.EntityId == entity.Id).Count() > 0){
                
                entities_copy.Add(entity);

                var row = new List<double>();

                foreach (var attr in attrs)
                {
                        //si el atributo de la entidad a recomendar esta en los atributos de la recomendacion
                        var e =entity.Attributes?? new List<AttributeEntity>();
                        if (e.Select(a => a.Value)
                                             .Contains(attr.Value))
                        {
                            //agregar 1 a la fila
                            row.Add(1);
                        }
                        else
                        {
                            //agregar 0 a la fila
                            row.Add(0);
                        }
                }

                matrizEncodings.Add(row);
            }
        }

        _logger.LogInformation("Matriz de encodings: " + matrizEncodings.Count);


        var resultMultiplication = new List<List<double>>();
        
          foreach (var row in matrizEncodings)
        {
            var resultRow = new List<double>();
            for (int i = 0; i < row.Count; i++)
            {   
                if(i > profileList.Count ){
                    break;
                }
                if (row.Count != profileList.Count)
                {
                    _logger.LogInformation("No se puede multiplicar");
                    break;
                }
                _logger.LogInformation("Multiplicando: " + row[i] + " * " + profileList[i].Weight);
                resultRow.Add(row[i] * profileList[i].Weight);
            }
            resultMultiplication.Add(resultRow);
        }

        var vectorSum = new List<double>();
        //sumar columnas
        for(int i=0; i < resultMultiplication.Count; i++){
            vectorSum.Add(resultMultiplication[i].Sum());
        }

        for(int i=0;i<vectorSum.Count;i++){
            Entity entity = entities_copy[i];
            
            Recommendation r = new Recommendation{
                EntityId = entity.Id,
                ProfileId = profileId,
                Weight = vectorSum[i],
                IsRecommended = true,
                IsAccepted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            result.Add(r);

            _context.Recommendations?.Add(r);
            
        }
        _context.SaveChanges();
        //obtener las primeras 10 recomendaciones con peso mas alto
        var recomendations_entities = result.OrderByDescending(r => r.Weight).Take(10).ToList();

        var entities_recomendations = new List<Entity>();

        entities_recomendations = entities.Where(e => recomendations_entities.Select(r => r.EntityId).Contains(e.Id)).ToList();

        ICollection<EntityResponse> entitiesResponse = new List<EntityResponse>();
        return  entities_recomendations.Select(e => new EntityResponse{
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Indentifier = e.Identifier,
            Attributes = e.Attributes.Select(a => new AtrributeEntityResponse{
                Id = a.Id,
                KeyAttr = a.KeyAttr,
                EntityId = a.EntityId,
                Weight = a.Weight,
                Value = a.Value,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            }).ToList()
        }).ToList();

    }


    public void Save(RecommendationRequest request){
        
        var  recomendation = new Recommendation{
                ProfileId = request.ProfileId,
                EntityId = request.EntityId,
                Weight = request.Weight,
                IsAccepted = true,
                IsRecommended = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
        };

        _context.Recommendations?.Add(recomendation);

        _context.SaveChanges();
    }


    public void DeleteAll(int profileId){
        var recomendations = _context.Recommendations.Where(r => r.ProfileId == profileId).ToList();

        foreach(var r in recomendations){
            _context.Recommendations?.Remove(r);
        }

        _context.SaveChanges();
    }
    

    public Recommendation Update(int id, RecommendationRequest r){
        var recomendation = _context.Recommendations.Where(r => r.Id == id).FirstOrDefault();

        if(recomendation != null){
            recomendation.IsAccepted = r.IsAccepted;
            recomendation.IsRecommended = r.IsRecommended;
            recomendation.UpdatedAt = DateTime.Now;

            _context.Recommendations?.Update(recomendation);
            _context.SaveChanges();
        }

        return recomendation;
    }
    
}

public interface IRecomendationService {

    ICollection<AtrributeEntityResponse> Train(int profileId,int OwnerId);

    ICollection<EntityResponse> GetRecomendations(int profileId,int OwnerId);

    void Save(RecommendationRequest request);

    void DeleteAll(int profileId);

    Recommendation Update(int id, RecommendationRequest r);
}

