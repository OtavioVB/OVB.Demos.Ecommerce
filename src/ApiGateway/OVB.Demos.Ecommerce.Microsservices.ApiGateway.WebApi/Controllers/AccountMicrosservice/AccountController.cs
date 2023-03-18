using Grpc.Core;
using Grpc.Net.Client;
using GrpcAccountClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers.AccountMicrosservice.Payloads;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers.AccountMicrosservice;

[ApiController]
[ApiVersion("1")]
[Route("api/gateway/v{version:apiVersion}/management/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateUserAccountPayloadInput input,
        CancellationToken cancellationToken)
    {
        var grpcChannel = GrpcChannel.ForAddress("http://localhost:5200", new GrpcChannelOptions());
        var client = new Account.AccountClient(grpcChannel);
        var call = await client.CreateUserAccountAsync(new CreateAccountInput()
        {
            ConfirmPassword = input.ConfirmPassword,
            CorrelationIdentifier = input.CorrelationIdentifier.ToString(),
            Email = input.Email,
            LastName = input.LastName,
            Name = input.Name,
            Password = input.Password,
            SourcePlatform = input.SourcePlatform,
            TenantIdentifier = input.TenantIdentifier.ToString(),
            Username = input.Username
        }, new CallOptions(cancellationToken: cancellationToken));

        if (call.StatusCode == 200 || call.StatusCode == 201)
        {
            return StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return StatusCode(call.StatusCode, call.Messages);
        }
    }
}
