using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class OrderRepository(CrmDbContext context) : IRepository<Order, int>
{
    public async Task<List<Order>> GetAsList()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task<List<Order>> GetAsList(Func<Order, bool> predicate)
    {
        return await Task.FromResult(context.Orders
            .Where(predicate)
            .ToList());
    }

    public async Task Add(Order newRecord)
    {
        await context.Orders.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var order = await context.Orders.FindAsync(key);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Order newValue)
    {
        var order = await context.Orders.FindAsync(newValue.OrderId);
        if (order != null)
        {
            order.OrderDate = newValue.OrderDate;
            order.OrderAmount = newValue.OrderAmount;
            order.ServiceCount = newValue.ServiceCount;
            order.EmployeeId = newValue.EmployeeId;
            order.ClientId = newValue.ClientId;

            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
    }
}