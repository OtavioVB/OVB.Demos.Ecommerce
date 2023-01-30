using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public IActionResult CreateAsync([FromServices] ITraceManager traceManager)
    {
        var dictionary = new Dictionary<string, string>();
        dictionary!.Add("CorrelationIdentifier", Guid.NewGuid().ToString());
        traceManager.StartTracing("CreateAccountController", ActivityKind.Internal, async (activity) =>
        {
            await Task.Delay(1000);
        }, dictionary);
        return StatusCode(201);
    }
}
