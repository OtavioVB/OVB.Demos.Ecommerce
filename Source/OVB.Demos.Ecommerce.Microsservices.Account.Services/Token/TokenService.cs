using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Services.Token;

public class TokenService
{
    /// <summary>
    /// Gerar Token JWT
    /// </summary>
    /// <param name="jwtKeyToken">Chave de tokenização</param>
    /// <returns>Token Gerado</returns>
    public string GenerateToken(string jwtKeyToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtKeyToken);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "Username"),
                new Claim(ClaimTypes.Role, "Employee")
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Gerar um novo Token Jwt
    /// </summary>
    /// <returns>Token Gerado</returns>
    /// <exception cref="NotImplementedException"></exception>
    public string RefreshToken()
    {
        throw new NotImplementedException();
    }
}
