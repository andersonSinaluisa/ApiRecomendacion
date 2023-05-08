using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
namespace api_recomendation.Tests;



public class BaseTest{

    private readonly TestServer _server;

    public HttpClient _client { get; }

    public BaseTest(){

        if (this._server == null){
            
        this._server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Program>());
        }

        this._client = this._server.CreateClient();
    
    }

    

}

