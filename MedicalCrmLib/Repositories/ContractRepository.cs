using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ContractRepository(CrmDbContext context) : IRepository<Contract, int>
{
    // Получение всех записей Contract
    public async Task<List<Contract>> GetAsList()
    {
        return await context.Contracts.ToListAsync();
    }

    // Получение записей Contract с фильтром
    public async Task<List<Contract>> GetAsList(Func<Contract, bool> predicate)
    {
        return await Task.FromResult(context.Contracts
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи Contract
    public async Task Add(Contract newRecord)
    {
        await context.Contracts.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    // Удаление записи Contract по ключу (Номер_договора)
    public async Task Delete(int key)
    {
        var contract = await context.Contracts.FindAsync(key);
        if (contract != null)
        {
            context.Contracts.Remove(contract);
            await context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Contract
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