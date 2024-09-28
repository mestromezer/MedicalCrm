using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class LaboratoryRepository(CrmDbContext context) : IRepository<Laboratory, string>
{
    public async Task<List<Laboratory>> GetAsList()
    {
        return await context.Laboratories.ToListAsync();
    }

    public async Task<List<Laboratory>> GetAsList(Func<Laboratory, bool> predicate)
    {
        return await Task.FromResult(context.Laboratories.Where(predicate).ToList());
    }

    public async Task Add(Laboratory newRecord)
    {
        await context.Laboratories.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(string key)
    {
        var laboratory = await context.Laboratories.FindAsync(key);
        if (laboratory != null)
        {
            context.Laboratories.Remove(laboratory);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Laboratory newValue)
    {
        var laboratory = await context.Laboratories.FindAsync(newValue.LaboratoryName);
        if (laboratory != null)
        {
            laboratory.LaboratoryAddress = newValue.LaboratoryAddress;
            laboratory.LaboratoryPhoneNumber = newValue.LaboratoryPhoneNumber;
            laboratory.NumberOfEmployees = newValue.NumberOfEmployees;

            context.Laboratories.Update(laboratory);
            await context.SaveChangesAsync();
        }
    }
}