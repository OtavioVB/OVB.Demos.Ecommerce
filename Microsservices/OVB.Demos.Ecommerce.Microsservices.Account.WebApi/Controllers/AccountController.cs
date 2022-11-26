using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// Criar Autenticação e Autorização de conta Usuário
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateAuthentication()
        {
            return await Task.FromResult(StatusCode(503));
        }
    }
}