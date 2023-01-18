using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi.Controllers.Base;

public abstract class CustomController : ControllerBase
{
    protected async Task<IActionResult> RunUseCaseAsync<TInput>(
        IUseCase<TInput> useCase,
        TInput input)
        where TInput : class
    {
        var useCaseResponse = await useCase.ExecuteUseCaseAsync(input);

        if (useCaseResponse == true)
        {
            return StatusCode(201);
        }
        else
        {
            return StatusCode(422);
        }
    }
}
