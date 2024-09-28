using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ClientRepository(CrmDbContext context) : IRepository<Client, int>
{
    public async Task<List<Client>> GetAsList()
    {
        return await context.Clients.ToListAsync();
    }

    public async Task<List<Client>> GetAsList(Func<Client, bool> predicate)
    {
        return await Task.FromResult(context.Clients.Where(predicate).ToList());
    }

    public async Task Add(Client newRecord)
    {
        await context.Clients.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var client = await context.Clients.FindAsync(key);
        if (client != null)
        {
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Client newValue)
    {
        var client = await context.Clients.FindAsync(newValue.ClientId);
        if (client != null)
        {
            client.Address = newValue.Address;
            client.ContactNumber = newValue.ContactNumber;
            client.Email = newValue.Email;
            client.FullName = newValue.FullName;
            client.BirthDate = newValue.BirthDate;
            client.Gender = newValue.Gender;
            client.CompanyName = newValue.CompanyName;

            context.Clients.Update(client);
            await context.SaveChangesAsync();
        }
    }
}