using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class OrderServiceRepository(CrmDbContext context) : IRepository<OrderService, int>
{
    public async Task<List<OrderService>> GetAsList()
    {
        return await context.OrderServices
            .ToListAsync();
    }

    public async Task<List<OrderService>> GetAsList(Func<OrderService, bool> predicate)
    {
        return await Task.FromResult(context.OrderServices
            .Where(predicate)
            .ToList());
    }

    public async Task Add(OrderService newRecord)
    {
        await context.OrderServices.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var orderService = await context.OrderServices.FindAsync(key);
        if (orderService != null)
        {
            context.OrderServices.Remove(orderService);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(OrderService newValue)
    {
        var orderService = await context.OrderServices.FindAsync(newValue.OrderServiceId);
        if (orderService != null)
        {
            orderService.ServiceListId = newValue.ServiceListId;
            orderService.OrderId = newValue.OrderId;

            context.OrderServices.Update(orderService);
            await context.SaveChangesAsync();
        }
    }
}