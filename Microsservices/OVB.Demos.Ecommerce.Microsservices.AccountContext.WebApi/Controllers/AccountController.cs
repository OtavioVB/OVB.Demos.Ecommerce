using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi.Controllers.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : CustomController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAsync(
        [FromServices] IUseCase<CreateAccountUseCaseInput> useCase,
        [FromBody] CreateAccountUseCaseInput input,
        CancellationToken cancellationToken
        )
    {
        return await RunUseCaseAsync(useCase, new CreateAccountUseCaseInput(input.Email, input.Username, input.Password, input.ConfirmPassword), cancellationToken);
    }
}
