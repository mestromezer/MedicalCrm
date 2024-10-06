using MedicalCrmLib.Dtos;
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmWebApplication.Services;

public class SecurityService(IJwtServiceWithRoles jwtService, 
    ILogger<SecurityService> logger, 
    IRepository<Account, string> accountRepository): ISecurityService
{
    public async Task RegisterUser(RegisterDto dto)
    {
        if (await UserRegistered(dto.Login))
            throw new ArgumentException("Пользователь с там логином уже зарегистрирован.");
        
        var newbie = new Account()
        {
            Login = dto.Login,
            Password = dto.Password,
            UserRole = dto.Role
        };

        await accountRepository.Add(newbie);
    }

    public async Task<string> GetUserJwt(LoginDto dto)
    {
        var users = await accountRepository.GetAsList();

        var target = users.FirstOrDefault(u => u.Login == dto.Login);

        if (target == null)
            throw new ArgumentException("Пользователь не найден");
        
        if (target.Password != dto.Password)
            throw new ArgumentException("Неверный пароль");
        
        if (target.UserRole == null)
            throw new NullReferenceException("У пользоваителя не задана роль.");

        return jwtService.Generate(target.Login, target.UserRole);
    }

    public void LogoutUser(ref HttpResponse response)
    {
        try
        {
            response.Cookies.Delete("jwt");
        }
        catch (Exception ex)
        {
            logger.LogError($"Ошибка удаления JWT token\nСообщение: {ex.Message}");
            response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

    private async Task<bool> UserRegistered(string login)
    {
        var users = await accountRepository.GetAsList();
        return users.FirstOrDefault(a => a.Login == login) != null;
    }
}