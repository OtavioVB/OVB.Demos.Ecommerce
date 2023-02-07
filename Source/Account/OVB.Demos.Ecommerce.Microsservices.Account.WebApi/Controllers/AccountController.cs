using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IUseCase<CreateAccountUseCaseInput> useCaseCreateAccount,
        [FromBody] CreateAccountUseCaseInput useCaseInput,
        CancellationToken cancellationToken)
    {
        return StatusCode(201, await useCaseCreateAccount.ExecuteUseCaseAsync(useCaseInput, cancellationToken));
    }
}
