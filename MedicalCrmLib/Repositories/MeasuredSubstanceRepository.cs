using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class MeasuredSubstanceRepository(CrmDbContext context) : IRepository<MeasuredSubstance, int>
{
    public async Task<List<MeasuredSubstance>> GetAsList()
    {
        return await context.MeasuredSubstances.ToListAsync();
    }

    public async Task<List<MeasuredSubstance>> GetAsList(Func<MeasuredSubstance, bool> predicate)
    {
        return await Task.FromResult(context.MeasuredSubstances
            .Where(predicate)
            .ToList());
    }

    public async Task Add(MeasuredSubstance newRecord)
    {
        await context.MeasuredSubstances.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var measuredSubstance = await context.MeasuredSubstances.FindAsync(key);
        if (measuredSubstance != null)
        {
            context.MeasuredSubstances.Remove(measuredSubstance);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(MeasuredSubstance newValue)
    {
        var measuredSubstance = await context.MeasuredSubstances.FindAsync(newValue.MeasuredSubstanceId);
        if (measuredSubstance != null)
        {
            measuredSubstance.Name = newValue.Name;
            measuredSubstance.MeasurementUnit = newValue.MeasurementUnit;
            measuredSubstance.ReferenceValues = newValue.ReferenceValues;
            measuredSubstance.Age = newValue.Age;
            measuredSubstance.ServiceListId = newValue.ServiceListId;

            context.MeasuredSubstances.Update(measuredSubstance);
            await context.SaveChangesAsync();
        }
    }
}