using Grpc.Core;
using OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}