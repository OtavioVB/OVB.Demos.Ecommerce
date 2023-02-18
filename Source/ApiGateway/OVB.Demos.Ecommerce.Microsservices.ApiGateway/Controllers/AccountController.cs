using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAccount()
    {
        return await Task.FromResult(StatusCode(503));
    }
}