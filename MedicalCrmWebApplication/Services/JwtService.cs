using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MedicalCrmLib.Interfaces;

namespace MedicalCrmWebApplication.Services;

public class JwtService: IJwtServiceWithRoles
{
    private const string SecureKey = "change me please change me please";

    public JwtSecurityToken? JwtSecurityToken(HttpRequest request)
    {
        var jwt = request.Cookies["jwt"];
        if (jwt == null)
        {
            return null;
        }
        var verifiedJwt = Verify(jwt);
        return verifiedJwt;
    }
    
    public string Generate(string login, string role)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecureKey));
        var credential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var header = new JwtHeader(credential);

        var payload = 
            new JwtPayload(
                issuer: login,
                audience: null, 
                claims: [new Claim("role" ,role)], 
                notBefore: null, 
                expires: DateTime.Today.AddDays(1)
                );
        
        var securityToken = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private static JwtSecurityToken Verify(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(SecureKey);
        tokenHandler.ValidateToken(
            jwt, 
            new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            },
            out SecurityToken validatedToken
        );
        return (JwtSecurityToken) validatedToken;
    }
}