using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class MeasuredSubstanceRepository : IRepository<MeasuredSubstance, int>
{
    private readonly CrmDbContext _context;

    public MeasuredSubstanceRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей MeasuredSubstance
    public async Task<List<MeasuredSubstance>> GetAsList()
    {
        return await _context.MeasuredSubstances.ToListAsync();
    }

    // Получение записей MeasuredSubstance с фильтром
    public async Task<List<MeasuredSubstance>> GetAsList(Func<MeasuredSubstance, bool> predicate)
    {
        return await Task.FromResult(_context.MeasuredSubstances
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи MeasuredSubstance
    public async Task Add(MeasuredSubstance newRecord)
    {
        await _context.MeasuredSubstances.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи MeasuredSubstance по ключу (ID_измеряемого_вещества)
    public async Task Delete(int key)
    {
        var measuredSubstance = await _context.MeasuredSubstances.FindAsync(key);
        if (measuredSubstance != null)
        {
            _context.MeasuredSubstances.Remove(measuredSubstance);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи MeasuredSubstance
    public async Task Update(MeasuredSubstance newValue)
    {
        var measuredSubstance = await _context.MeasuredSubstances.FindAsync(newValue.MeasuredSubstanceId);
        if (measuredSubstance != null)
        {
            measuredSubstance.Name = newValue.Name;
            measuredSubstance.MeasurementUnit = newValue.MeasurementUnit;
            measuredSubstance.ReferenceValues = newValue.ReferenceValues;
            measuredSubstance.Age = newValue.Age;
            measuredSubstance.ServiceListId = newValue.ServiceListId;

            _context.MeasuredSubstances.Update(measuredSubstance);
            await _context.SaveChangesAsync();
        }
    }
}