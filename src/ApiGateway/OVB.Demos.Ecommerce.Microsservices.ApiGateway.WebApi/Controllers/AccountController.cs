using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var grpcChannel = GrpcChannel.ForAddress("http://localhost:5200", new GrpcChannelOptions());
        var client = new GrpcAccountClient.Account.AccountClient(grpcChannel);
        var call = await client.CreateUserAccountAsync(new GrpcAccountClient.CreateAccountInput(){}, new CallOptions());
        return await Task.FromResult(StatusCode(StatusCodes.Status503ServiceUnavailable, string.Format($"Grpc Service Ok {call.StatusCode}")));
    }
}