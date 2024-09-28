using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ProtectiveEquipmentJournalRepository(CrmDbContext context)
    : IRepository<ProtectiveEquipmentJournal, (string EquipmentName, int EmployeeId)>
{
    public async Task<List<ProtectiveEquipmentJournal>> GetAsList()
    {
        return await context.ProtectiveEquipmentJournals.ToListAsync();
    }

    public async Task<List<ProtectiveEquipmentJournal>> GetAsList(Func<ProtectiveEquipmentJournal, bool> predicate)
    {
        return await Task.FromResult(context.ProtectiveEquipmentJournals
            .Where(predicate)
            .ToList());
    }

    public async Task Add(ProtectiveEquipmentJournal newRecord)
    {
        await context.ProtectiveEquipmentJournals.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete((string EquipmentName, int EmployeeId) key)
    {
        var journal = await context.ProtectiveEquipmentJournals.FindAsync(key.EquipmentName, key.EmployeeId);
        if (journal != null)
        {
            context.ProtectiveEquipmentJournals.Remove(journal);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(ProtectiveEquipmentJournal newValue)
    {
        var journal = await context.ProtectiveEquipmentJournals.FindAsync(newValue.EquipmentName, newValue.EmployeeId);
        if (journal != null)
        {
            journal.EquipmentCount = newValue.EquipmentCount;
            journal.RequiredEquipmentCount = newValue.RequiredEquipmentCount;
            journal.EmployeeId = newValue.EmployeeId;

            context.ProtectiveEquipmentJournals.Update(journal);
            await context.SaveChangesAsync();
        }
    }
}