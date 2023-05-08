using api_recomendation.Config.DatabaseContext;
using api_recomendation.Models.Core;
using api_recomendation.HttpModels.V1.Core;
namespace api_recomendation.Services.Core;


public class ProfileService: IProfileService {

    private readonly DatabaseContext _context;

    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }

    public Profile Add(ProfileRequest profile, int OwnerId){

        var newProfile = new Profile{
            Identifier = profile.Identifier,
            TypeIdentifier = profile.TypeIdentifier,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            OwnerId = OwnerId
        };

        _context.Profiles.Add(newProfile);
        _context.SaveChanges();

        return newProfile;
    }

    public ProfileResponse Get(int id){

        var profile = _context.Profiles.Find(id);

        if(profile == null){
            return null;
        }

        return new ProfileResponse{
            Id = profile.Id,
            Identifier = profile.Identifier,
            TypeIdentifier = profile.TypeIdentifier,
            CreatedAt = profile.CreatedAt,
            UpdatedAt = profile.UpdatedAt
        };
    }

    public ProfileResponse GetByOwner(int OwnerId){

        var profile = _context.Profiles.Where(p => p.OwnerId == OwnerId).FirstOrDefault();

        if(profile == null){
            return null;
        }

        return new ProfileResponse{
            Id = profile.Id,
            Identifier = profile.Identifier,
            TypeIdentifier = profile.TypeIdentifier,
            CreatedAt = profile.CreatedAt,
            UpdatedAt = profile.UpdatedAt
        };
    }

    public ProfileResponse Update(int id, ProfileRequest profile){

        var profileToUpdate = _context.Profiles.Find(id);

        if(profileToUpdate == null){
            return null;
        }

        profileToUpdate.Identifier = profile.Identifier;
        profileToUpdate.TypeIdentifier = profile.TypeIdentifier;
        profileToUpdate.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return new ProfileResponse{
            Id = profileToUpdate.Id,
            Identifier = profileToUpdate.Identifier,
            TypeIdentifier = profileToUpdate.TypeIdentifier,
            CreatedAt = profileToUpdate.CreatedAt,
            UpdatedAt = profileToUpdate.UpdatedAt
        };
    }

    public bool Delete(int id){

        var profileToDelete = _context.Profiles.Find(id);

        if(profileToDelete == null){
            return false;
        }

        _context.Profiles.Remove(profileToDelete);
        _context.SaveChanges();

        return true;
    }



}

public interface IProfileService {

    Profile Add(ProfileRequest profile, int OwnerId);

    ProfileResponse Get(int id);

    ProfileResponse GetByOwner(int OwnerId);

    ProfileResponse Update(int id, ProfileRequest profile);

    bool Delete(int id);
}