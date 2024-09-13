using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ClientRepository : IRepository<Client, int>
{
    private readonly CrmDbContext _context;

    public ClientRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Client
    public async Task<List<Client>> GetAsList()
    {
        return await _context.Clients.ToListAsync();
    }

    // Получение записей Client с фильтром
    public async Task<List<Client>> GetAsList(Func<Client, bool> predicate)
    {
        return await Task.FromResult(_context.Clients.Where(predicate).ToList());
    }

    // Добавление новой записи Client
    public async Task Add(Client newRecord)
    {
        await _context.Clients.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Client по ключу (ID_Клиента)
    public async Task Delete(int key)
    {
        var client = await _context.Clients.FindAsync(key);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Client
    public async Task Update(Client newValue)
    {
        var client = await _context.Clients.FindAsync(newValue.ClientId);
        if (client != null)
        {
            client.Address = newValue.Address;
            client.ContactNumber = newValue.ContactNumber;
            client.Email = newValue.Email;
            client.FullName = newValue.FullName;
            client.BirthDate = newValue.BirthDate;
            client.Gender = newValue.Gender;
            client.CompanyName = newValue.CompanyName;

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}