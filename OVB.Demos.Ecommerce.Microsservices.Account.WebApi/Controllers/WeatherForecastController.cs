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
            return await Task.FromResutlt(StatusCode(500, "Recurso não implementado"));
        }
    }
}