using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace MedicalCrmLib.Interfaces;

public interface IJwtServiceWithRoles
{
    public JwtSecurityToken? JwtSecurityToken(HttpRequest request);
    public string Generate(string login, string role);
}