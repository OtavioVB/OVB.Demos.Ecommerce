using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers;

public abstract class HandleBase<Response, Request> : IHandler<Response, Request>
    where Response : IResponse
    where Request : IRequest
{
    public abstract Task<Response> HandleAsync(Request request);
}
