using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        return await Task.FromResult(StatusCode(StatusCodes.Status503ServiceUnavailable));
    }
}