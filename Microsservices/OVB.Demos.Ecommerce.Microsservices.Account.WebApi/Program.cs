using OVB.Core.Services.CrossCuting;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;
using OVB.Deoms.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<CreateAccountResponse>(p => { return new CreateAccountResponse(new HttpStatusResponse(TypeHttpResponseCode.BadRequest)); });
        builder.Services.AddScoped<HandleBase<CreateAccountResponse, CreateAccountRequest>, CreateAccountHandler>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}