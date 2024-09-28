using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmWebClient.Srvices;

public class AuthenticationService: IAuthenticationService
{
    // Метод регистрации нового пользователя
    public async Task<bool> RegisterAsync(Account account)
    {
        // Здесь можно добавить логику для сохранения пользователя в базе данных
        // Например, проверка на существование пользователя и хэширование пароля
        return true;
    }

    // Метод логина
    public async Task<bool> LoginAsync(string username, string password)
    {
        // Здесь можно добавить логику для проверки учетных данных
        // Например, сверить хэш пароля и логин с базой данных
        return true;
    }
}