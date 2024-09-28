using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AnalysisRepository(CrmDbContext context) : IRepository<Analysis, int>
{
    public async Task<List<Analysis>> GetAsList()
    {
        return await context.Analyses.ToListAsync();
    }

    public async Task<List<Analysis>> GetAsList(Func<Analysis, bool> predicate)
    {
        return await Task.FromResult(context.Analyses.Where(predicate).ToList());
    }

    public async Task Add(Analysis newRecord)
    {
        await context.Analyses.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var analysis = await context.Analyses.FindAsync(key);
        if (analysis != null)
        {
            context.Analyses.Remove(analysis);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Analysis newValue)
    {
        var analysis = await context.Analyses.FindAsync(newValue.AnalysisCode);
        if (analysis != null)
        {
            analysis.SampleDate = newValue.SampleDate;
            analysis.BiomaterialType = newValue.BiomaterialType;
            analysis.OrderId = newValue.OrderId;

            context.Analyses.Update(analysis);
            await context.SaveChangesAsync();
        }
    }
}