using Microsoft.AspNetCore.Mvc;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers;
using OVB.Deoms.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] HandleBase<CreateAccountResponse, CreateAccountRequest> handler, [FromServices] IServiceProvider serviceProvider)
        {
            return await Task.FromResult(StatusCode(handler.HandleAsync(new CreateAccountRequest(Guid.NewGuid(), "Teste"), serviceProvider).Result.HttpResponse.Status));
        }
    }
}