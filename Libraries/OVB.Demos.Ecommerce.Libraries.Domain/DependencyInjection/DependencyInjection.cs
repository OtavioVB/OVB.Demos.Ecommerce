using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Domain.Validators;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainValidatorsConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<AbstractValidator<Email>, EmailValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Name>, NameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<LastName>, LastNameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Username>, UsernameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Password>, PasswordValidator>();

        return serviceCollection;
    }
}
