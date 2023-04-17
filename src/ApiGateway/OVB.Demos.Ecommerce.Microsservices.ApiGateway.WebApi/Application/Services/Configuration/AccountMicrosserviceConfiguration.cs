using Grpc.Net.Client;
using GrpcAccountClient;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Configuration.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Application.Services.Configuration;

public sealed class AccountMicrosserviceConfiguration : IAccountMicrosserviceConfiguration
{
    public GrpcChannel GrpcChannel { get; init; }

    public AccountMicrosserviceConfiguration(string channelUrl)
    {
        GrpcChannel = GrpcChannel.ForAddress(channelUrl, new GrpcChannelOptions());
    }

    public Account.AccountClient GetAccountClient()
    {
        return new Account.AccountClient(GrpcChannel);
    }
}
