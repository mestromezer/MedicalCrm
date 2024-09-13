using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AnalysisRepository : IRepository<Analysis, int>
{
    private readonly CrmDbContext _context;

    public AnalysisRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Analysis
    public async Task<List<Analysis>> GetAsList()
    {
        return await _context.Analyses.ToListAsync();
    }

    // Получение записей Analysis с фильтром
    public async Task<List<Analysis>> GetAsList(Func<Analysis, bool> predicate)
    {
        return await Task.FromResult(_context.Analyses.Where(predicate).ToList());
    }

    // Добавление новой записи Analysis
    public async Task Add(Analysis newRecord)
    {
        await _context.Analyses.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Analysis по ключу (Код_анализа)
    public async Task Delete(int key)
    {
        var analysis = await _context.Analyses.FindAsync(key);
        if (analysis != null)
        {
            _context.Analyses.Remove(analysis);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Analysis
    public async Task Update(Analysis newValue)
    {
        var analysis = await _context.Analyses.FindAsync(newValue.AnalysisCode);
        if (analysis != null)
        {
            analysis.SampleDate = newValue.SampleDate;
            analysis.BiomaterialType = newValue.BiomaterialType;
            analysis.OrderId = newValue.OrderId;

            _context.Analyses.Update(analysis);
            await _context.SaveChangesAsync();
        }
    }
}