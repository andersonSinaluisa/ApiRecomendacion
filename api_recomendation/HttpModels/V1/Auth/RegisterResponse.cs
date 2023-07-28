using api_recomendation.Models.Auth;

namespace api_recomendation.HttpModels.V1.Auth
{
    public class RegisterResponse: User{

        public RegisterResponse(User user){
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
            IsStaff = user.IsStaff;
            IsSuperUser = user.IsSuperUser;
            IsAuthenticated = user.IsAuthenticated;
            DateJoined = user.DateJoined;
            LastLogin = user.LastLogin;
            RoleId = user.RoleId;
        }
    }

}