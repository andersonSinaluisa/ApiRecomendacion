using api_recomendation.HttpModels.V1.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace api_recomendation.Controllers.Api.V1.Admin;

[Route("api/v1/admin/[controller]")]
//ignore swagger
[ApiExplorerSettings(IgnoreApi = true)]
public class CheckoutController: ControllerBase{


    private readonly IConfiguration _configuration;


    public CheckoutController(IConfiguration configuration){
        _configuration = configuration;
    }

    [HttpPost]
    [Authorize]
    public IActionResult Checkout([FromBody] CheckoutRequest request){
        
        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        
        var intent = new PaymentIntentCreateOptions{
            Amount = request.Amount,
            Currency = "usd",
            PaymentMethodTypes = new List<string>{
                "card"
            }
        };

        var service = new PaymentIntentService();
        var paymentIntent = service.Create(intent);

        
        return Ok();
    }
}