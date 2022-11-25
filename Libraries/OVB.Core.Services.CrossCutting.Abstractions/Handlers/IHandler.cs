using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers;

public interface IHandler<Response, Request>
    where Response : IResponse
    where Request : IRequest
{
    Task<Response> HandleAsync(Request request, IServiceProvider serviceProvider);
    public abstract Task<Response> HandleWorkflowAsync(Request request);
    public abstract Response DefaultResponseForInvalidRequest(IServiceProvider serviceProvider);
}
