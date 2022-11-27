using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OVB.Core.Services.CrossCuting;
using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;
using OVB.Demos.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<CreateAuthenticationResponse>(p =>
        {
            return new CreateAuthenticationResponse(new HttpStatusResponse(TypeHttpResponseCode.BadRequest));
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("")),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Standard", policy => policy.RequireRole("Standard"));
            options.AddPolicy("Manager", policy => policy.RequireRole("Manager"));
            options.AddPolicy("Developer", policy => policy.RequireRole("Developer"));
        });

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}