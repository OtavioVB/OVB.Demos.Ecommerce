using Grpc.Core;
using Grpc.Net.Client;
using GrpcAccountClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers;

[ApiVersion("1")]
[Route("api/gateway/v{version:apiVersion}/management/[controller]")]
[ApiController]
public sealed class HealthChecksController : ControllerBase
{
    [HttpGet]
    [Route("ReadinessCheck")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceReadiness[]))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ServiceReadiness[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public async Task<IActionResult> ReadinessCheckAsync(
        CancellationToken cancellationToken)
    {
        try
        {
            var grpcChannel = GrpcChannel.ForAddress("http://localhost:5100", new GrpcChannelOptions());
            var client = new HealthChecks.HealthChecksClient(grpcChannel);
            var call = await client.ReadinessHealthCheckAsync(new ReadinessHealthCheckInput() { }, new CallOptions(cancellationToken: cancellationToken));

            if (call.Ready == "Unhealthy")
                return StatusCode(StatusCodes.Status400BadRequest, call.Services.ToArray());
            else
                return StatusCode(StatusCodes.Status200OK, call.Services.ToArray());
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, new List<ServiceReadiness>()
            {
                new ServiceReadiness()
                {
                    ServiceName = "Microsservice Account",
                    ServiceDescription = "Microsserviço para a realização de monitoramento, processamento e relatórios de dados relacionados a autenticação e dados de privacidade dos usuários.",
                    ServiceIsReady = HealthCheckStatus.Unhealthy.ToString(),
                    ServiceVersion = "0.0.1-alpha"
                }
            });
        }
    }
}
