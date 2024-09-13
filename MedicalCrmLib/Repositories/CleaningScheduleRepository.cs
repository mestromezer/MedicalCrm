using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class CleaningScheduleRepository : IRepository<CleaningSchedule, (int RoomNumber, DateTime CleaningDate)>
{
    private readonly CrmDbContext _context;

    public CleaningScheduleRepository(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<List<CleaningSchedule>> GetAsList()
    {
        return await _context.CleaningSchedules.ToListAsync();
    }

    public async Task<List<CleaningSchedule>> GetAsList(Func<CleaningSchedule, bool> predicate)
    {
        return await Task.FromResult(_context.CleaningSchedules
            .Where(predicate)
            .ToList());
    }

    public async Task Add(CleaningSchedule newRecord)
    {
        await _context.CleaningSchedules.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    public async Task Delete((int RoomNumber, DateTime CleaningDate) key)
    {
        var cleaningSchedule = await _context.CleaningSchedules.FindAsync(key.RoomNumber, key.CleaningDate);
        if (cleaningSchedule != null)
        {
            _context.CleaningSchedules.Remove(cleaningSchedule);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(CleaningSchedule newValue)
    {
        var cleaningSchedule = await _context.CleaningSchedules.FindAsync(newValue.RoomNumber, newValue.CleaningDate);
        if (cleaningSchedule != null)
        {
            cleaningSchedule.EmployeeId = newValue.EmployeeId;

            _context.CleaningSchedules.Update(cleaningSchedule);
            await _context.SaveChangesAsync();
        }
    }
}