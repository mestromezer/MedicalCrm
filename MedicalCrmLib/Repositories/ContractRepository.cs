using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ContractRepository(CrmDbContext context) : IRepository<Contract, int>
{
    public async Task<List<Contract>> GetAsList()
    {
        return await context.Contracts.ToListAsync();
    }

    public async Task<List<Contract>> GetAsList(Func<Contract, bool> predicate)
    {
        return await Task.FromResult(context.Contracts
            .Where(predicate)
            .ToList());
    }

    public async Task Add(Contract newRecord)
    {
        await context.Contracts.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var contract = await context.Contracts.FindAsync(key);
        if (contract != null)
        {
            context.Contracts.Remove(contract);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Contract newValue)
    {
        var contract = await context.Contracts.FindAsync(newValue.ContractNumber);
        if (contract != null)
        {
            contract.ContractDate = newValue.ContractDate;
            contract.LaboratoryName = newValue.LaboratoryName;
            contract.ClientId = newValue.ClientId;

            context.Contracts.Update(contract);
            await context.SaveChangesAsync();
        }
    }
}