using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AccountRepository : IRepository<Account, string>
{
    private readonly CrmDbContext _context;

    public AccountRepository(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<List<Account>> GetAsList()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<List<Account>> GetAsList(Func<Account, bool> predicate)
    {
        return await Task.FromResult(_context.Accounts.Where(predicate).ToList());
    }

    public async Task Add(Account newRecord)
    {
        await _context.Accounts.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string key)
    {
        var account = await _context.Accounts.FindAsync(key);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Account newValue)
    {
        var account = await _context.Accounts.FindAsync(newValue.Login);
        if (account != null)
        {
            account.Password = newValue.Password;
            account.UserRole = newValue.UserRole;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}