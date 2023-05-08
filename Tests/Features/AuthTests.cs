
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using api_recomendation.HttpModels.V1.Auth;

namespace api_recomendation.Tests.Features;


public class AuthTests : BaseTest{


    public AuthTests() : base(){
        
    }

    [Fact]
    public void LoginTest(){
        // Arrange
        var data = this._client.PostAsJsonAsync("/api/v1/auth/register", new RegisterRequest{
            Name = "test",
            LastName = "test",
            UserName = "test",
            Email = " ",
            Password = "test"
        });

        // Act

        // Assert
        Assert.Equal<int>(((int)data.Result.StatusCode),200);



    }    

}

    


