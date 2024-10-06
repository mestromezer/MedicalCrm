using MedicalCrmLib.Dtos;
using Microsoft.AspNetCore.Http;

namespace MedicalCrmLib.Interfaces;

public interface ISecurityService
{
    public Task RegisterUser(RegisterDto dto);
    public Task<string> GetUserJwt(LoginDto dto);
    public void LogoutUser(ref HttpResponse response);
}