using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;
using System;

namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers;

public abstract class HandleBase<Response, Request> : IHandler<Response, Request>
    where Response : IResponse
    where Request : IRequest
{
    public async Task<Response> HandleAsync(Request request, IServiceProvider serviceProvider)
    {
        if (request is null)
        {
            return DefaultResponseForInvalidRequest(serviceProvider);
        }

        return await HandleWorkflowAsync(request);
    }

    public abstract Task<Response> HandleWorkflowAsync(Request request);
    
    public virtual Response DefaultResponseForInvalidRequest(IServiceProvider serviceProvider)
    {
        var getInstance = serviceProvider.GetService(typeof(Response));
        
        if (getInstance is null)
        {
            throw new InvalidOperationException();
        }

        return (Response)getInstance;
    }
}