using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.Controllers.Paylods;
using Google.Protobuf;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("CreateAccount")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccountAsync(
        [FromBody] CreateAccountPayloadInput input,
        CancellationToken cancellationToken)  
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:5048");
        var client = new GrpcGreeterClient.Account.AccountClient(channel);
        var response = await client.CreateAccountAsync(new GrpcGreeterClient.CreateAccountUseCaseGrpcInput()
        {
            CorrelationIdentifier = input.CorrelationIdentifier.ToString(),
            Email= input.Email,
            ExecutionSource= input.ExecutionSource,
            LastName= input.LastName,
            Name= input.Name,
            Password= input.Password,
            SourcePlatform=input.SourcePlatform,
            TenantIdentifier = input.TenantIdentifier.ToString(),
            Username= input.Username,
        });
        return StatusCode(201, response.Messages);
    }
}