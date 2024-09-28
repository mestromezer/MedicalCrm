using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class JournalRepository(CrmDbContext context) : IRepository<Journal, (int JournalId, DateTime Date)>
{
    public async Task<List<Journal>> GetAsList()
    {
        return await context.Journals.ToListAsync();
    }

    public async Task<List<Journal>> GetAsList(Func<Journal, bool> predicate)
    {
        return await Task.FromResult(context.Journals
            .Where(predicate)
            .ToList());
    }

    public async Task Add(Journal newRecord)
    {
        await context.Journals.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete((int JournalId, DateTime Date) key)
    {
        var journal = await context.Journals.FindAsync(key.JournalId, key.Date);
        if (journal != null)
        {
            context.Journals.Remove(journal);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Journal newValue)
    {
        var journal = await context.Journals.FindAsync(newValue.JournalId, newValue.Date);
        if (journal != null)
        {
            journal.EmployeeId = newValue.EmployeeId;
            journal.RoomNumber = newValue.RoomNumber;
            journal.ManufactureDate = newValue.ManufactureDate;
            journal.ExpiryDate = newValue.ExpiryDate;

            context.Journals.Update(journal);
            await context.SaveChangesAsync();
        }
    }
}