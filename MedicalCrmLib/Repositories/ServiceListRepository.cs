using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ServiceListRepository(CrmDbContext context) : IRepository<ServiceList, int>
{
    public async Task<List<ServiceList>> GetAsList()
    {
        return await context.ServiceListRecords
            .ToListAsync();
    }

    public async Task<List<ServiceList>> GetAsList(Func<ServiceList, bool> predicate)
    {
        return await Task.FromResult(context.ServiceListRecords
            .Where(predicate)
            .ToList());
    }

    public async Task Add(ServiceList newRecord)
    {
        await context.ServiceListRecords.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var serviceList = await context.ServiceListRecords.FindAsync(key);
        if (serviceList != null)
        {
            context.ServiceListRecords.Remove(serviceList);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(ServiceList newValue)
    {
        var serviceList = await context.ServiceListRecords.FindAsync(newValue.ServiceListId);
        if (serviceList != null)
        {
            serviceList.ServicePrice = newValue.ServicePrice;
            serviceList.ServiceName = newValue.ServiceName;
            serviceList.LaboratoryName = newValue.LaboratoryName;

            context.ServiceListRecords.Update(serviceList);
            await context.SaveChangesAsync();
        }
    }
}