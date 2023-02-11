using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers;

public class HealthChecks : ControllerBase
{
    public async Task<IActionResult> LivenessCheck()
    {
        return await Task.FromResult(StatusCode(503));
    }
}
