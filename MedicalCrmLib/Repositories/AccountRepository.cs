using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AccountRepository(CrmDbContext context) : IRepository<Account, string>
{
    public async Task<List<Account>> GetAsList()
    {
        return await context.Accounts.ToListAsync();
    }

    public async Task<List<Account>> GetAsList(Func<Account, bool> predicate)
    {
        return await Task.FromResult(context.Accounts.Where(predicate).ToList());
    }

    public async Task Add(Account newRecord)
    {
        await context.Accounts.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(string key)
    {
        var account = await context.Accounts.FindAsync(key);
        if (account != null)
        {
            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Account newValue)
    {
        var account = await context.Accounts.FindAsync(newValue.Login);
        if (account != null)
        {
            account.Password = newValue.Password;
            account.UserRole = newValue.UserRole;
            context.Accounts.Update(account);
            await context.SaveChangesAsync();
        }
    }
}