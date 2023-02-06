using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IUseCase<CreateAccountUseCaseInput> useCaseCreateAccount,
        [FromServices] ITraceManager traceManager,
        [FromBody] CreateAccountUseCaseInput useCaseInput,
        CancellationToken cancellationToken)
    {
        var useCaseResponse = await traceManager.StartTracing("CreateAccountController", ActivityKind.Internal, useCaseInput, async (input, activity) =>
        {
            return await useCaseCreateAccount.ExecuteUseCaseAsync(input, cancellationToken);
        }, new Dictionary<string, string>());
        return StatusCode(201, useCaseResponse);
    }
}
