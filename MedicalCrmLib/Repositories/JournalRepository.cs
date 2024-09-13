using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class JournalRepository : IRepository<Journal, (int JournalId, DateTime Date)>
{
    private readonly CrmDbContext _context;

    public JournalRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Journal
    public async Task<List<Journal>> GetAsList()
    {
        return await _context.Journals.ToListAsync();
    }

    // Получение записей Journal с фильтром
    public async Task<List<Journal>> GetAsList(Func<Journal, bool> predicate)
    {
        return await Task.FromResult(_context.Journals
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи Journal
    public async Task Add(Journal newRecord)
    {
        await _context.Journals.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Journal по ключу (ID_Журнала и Дата)
    public async Task Delete((int JournalId, DateTime Date) key)
    {
        var journal = await _context.Journals.FindAsync(key.JournalId, key.Date);
        if (journal != null)
        {
            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Journal
    public async Task Update(Journal newValue)
    {
        var journal = await _context.Journals.FindAsync(newValue.JournalId, newValue.Date);
        if (journal != null)
        {
            journal.EmployeeId = newValue.EmployeeId;
            journal.RoomNumber = newValue.RoomNumber;
            journal.ManufactureDate = newValue.ManufactureDate;
            journal.ExpiryDate = newValue.ExpiryDate;

            _context.Journals.Update(journal);
            await _context.SaveChangesAsync();
        }
    }
}