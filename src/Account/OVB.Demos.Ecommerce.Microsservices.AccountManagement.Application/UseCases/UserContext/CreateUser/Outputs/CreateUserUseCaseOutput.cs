namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Outputs;

public struct CreateUserUseCaseOutput
{
    public CreateUserUseCaseOutput(List<string>? notifications = null)
    {
        Notifications = notifications;
    }

    public List<string>? Notifications { get; init; }
}
