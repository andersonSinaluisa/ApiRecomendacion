using api_recomendation.Models.Core;
using api_recomendation.Config.DatabaseContext;
namespace api_recomendation.Services.Core;

public class RecomendationService : IRecomendationService{

    private readonly DatabaseContext _context;

    public RecomendationService(DatabaseContext context)
    {
        _context = context;
    }

    public ICollection<AttributeEntityProfile> Train(int profileId,int OwnerId)
    {   
        

        //Obtener las recomendaciones aceptadas del perfil
        Array recomendations = _context.Recommendations.Where(r => r.ProfileId == profileId && r.IsRecommended && r.IsAccepted).ToArray();

        
        //Obtener los atributos de la entidades a recomendar
        ICollection<AttributeEntity> attrs = _context.AttributeEntities.Where(a => a.EntityId == OwnerId).DistinctBy(a => a.KeyAttr).ToList();


        //crear matriz de encodings para las entidades ya recomendadas
        var matrizEncodings = new List<List<double>>();

        //crear vector de encodings para las entidades ya recomendadas y calificadas    
        var vectorEncodings = new List<double>();

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
                    if (recomendation.Entity.Attributes.Select(a => a.KeyAttr).Count()>0)
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



        //crear matriz de encodings para las entidades a recomendar
        var resultMultiplication = new List<List<double>>();
        for(int i = 0; i < vectorEncodings.Count; i++){
            for(int j = 0; j < matrizEncodings[i].Count; j++){
                resultMultiplication[i][j] = matrizEncodings[i][j] * vectorEncodings[i];
            }
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
        // Obtener la cantidad de columnas de la matriz
        int columnCount = resultMultiplication[0].Count;

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
        

        // Calcular el valor mínimo y máximo


        // Normalizar los valores
        List<double> normalizedResults = new List<double>();
        
       

        for(int i = 0; i < normalizedResults.Count; i++){
            var result = normalizedResults[i];
            double normalizedResult = result / columnSums.Sum();

            var attrId = attrs.Select(a => a.Id).ToList()[normalizedResults.IndexOf(i)];

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

        return profiletraint;
    }


    
    
}

public interface IRecomendationService {

    ICollection<AttributeEntityProfile> Train(int profileId,int OwnerId);
}

