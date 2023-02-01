using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects.Validators;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbDomainConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<AbstractValidator<Email>, EmailValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Username>, UsernameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Name>, NameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<LastName>, LastNameValidator>();
        serviceCollection.AddSingleton<AbstractValidator<Password>, PasswordValidator>();

        serviceCollection.AddSingleton<IBuilderAccount, BuilderAccount>();

        return serviceCollection;
    }
}
