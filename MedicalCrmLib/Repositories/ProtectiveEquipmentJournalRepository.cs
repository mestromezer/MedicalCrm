using MedicalCrmLib;
using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProtectiveEquipmentJournalRepository : IRepository<ProtectiveEquipmentJournal, (string EquipmentName, int EmployeeId)>
{
    private readonly CrmDbContext _context;

    public ProtectiveEquipmentJournalRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей ProtectiveEquipmentJournal
    public async Task<List<ProtectiveEquipmentJournal>> GetAsList()
    {
        return await _context.ProtectiveEquipmentJournals.ToListAsync();
    }

    // Получение записей ProtectiveEquipmentJournal с фильтром
    public async Task<List<ProtectiveEquipmentJournal>> GetAsList(Func<ProtectiveEquipmentJournal, bool> predicate)
    {
        return await Task.FromResult(_context.ProtectiveEquipmentJournals
                                              .Where(predicate)
                                              .ToList());
    }

    // Добавление новой записи ProtectiveEquipmentJournal
    public async Task Add(ProtectiveEquipmentJournal newRecord)
    {
        await _context.ProtectiveEquipmentJournals.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи ProtectiveEquipmentJournal по составному ключу (EquipmentName, EmployeeId)
    public async Task Delete((string EquipmentName, int EmployeeId) key)
    {
        var journal = await _context.ProtectiveEquipmentJournals.FindAsync(key.EquipmentName, key.EmployeeId);
        if (journal != null)
        {
            _context.ProtectiveEquipmentJournals.Remove(journal);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи ProtectiveEquipmentJournal
    public async Task Update(ProtectiveEquipmentJournal newValue)
    {
        var journal = await _context.ProtectiveEquipmentJournals.FindAsync(newValue.EquipmentName, newValue.EmployeeId);
        if (journal != null)
        {
            journal.EquipmentCount = newValue.EquipmentCount;
            journal.RequiredEquipmentCount = newValue.RequiredEquipmentCount;
            journal.EmployeeId = newValue.EmployeeId;

            _context.ProtectiveEquipmentJournals.Update(journal);
            await _context.SaveChangesAsync();
        }
    }
}
