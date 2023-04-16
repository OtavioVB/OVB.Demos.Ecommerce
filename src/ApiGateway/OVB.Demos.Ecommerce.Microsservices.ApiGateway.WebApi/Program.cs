using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        #region Builder Configuration

        var builder = WebApplication.CreateBuilder(args);

        #region Kestrel Configuration

        builder.WebHost.ConfigureKestrel(p =>
        {
            p.ListenAnyIP(8090, p =>
            {
                p.Protocols = HttpProtocols.Http1;
            });
        });

        #endregion

        #region Cors Configuration

        builder.Services.AddCors(options =>
            options.AddPolicy(name: "AllowAny", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
            })
        );

        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Api Versioning Configuration

        builder.Services.AddApiVersioning(p =>
        {
            p.DefaultApiVersion = new ApiVersion(0, 1);
            p.AssumeDefaultVersionWhenUnspecified = true;
            p.ReportApiVersions = true;
        });

        #endregion

        #region Jwt Bearer Token Configuration

        var securityJwtToken = builder.Configuration["Application:Security:JwtToken"];

        if (securityJwtToken is null)
            throw new Exception("Internal Jwt Token can not be null, please, configure your credentials with appsettings.json");

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityJwtToken)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        #endregion

        #endregion

        #region Application Configuration

        var app = builder.Build();

        #region Swagger Documentation

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        #endregion
        app.UseHttpsRedirection();
        app.UseCors("AllowAny");
        app.UseAuthorization();
        app.UseAuthentication();
        app.MapControllers();
        app.Run();

        #endregion
    }
}