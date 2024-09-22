using MedicalCrmLib.Model;

namespace MedicalCrmLib.Interfaces;

public interface IAuthenticationService
{
    public Task<bool> RegisterAsync(Account account);

    public Task<bool> LoginAsync(string username, string password);
}