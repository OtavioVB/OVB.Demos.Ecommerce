using Grpc.Net.Client;
using GrpcAccountClient;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Configuration.Interfaces;

public interface IAccountMicrosserviceConfiguration
{
    public GrpcChannel GrpcChannel { get; }

    public Account.AccountClient GetAccountClient();
}
