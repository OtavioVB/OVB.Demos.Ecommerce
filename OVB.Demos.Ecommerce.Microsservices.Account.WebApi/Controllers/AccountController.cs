using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(StatusCode(500, "Recurso não implementado"));
        }
    }
}