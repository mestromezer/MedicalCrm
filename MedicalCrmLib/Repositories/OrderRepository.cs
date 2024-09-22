using MedicalCrmLib;
using Microsoft.EntityFrameworkCore;
using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

public class OrderRepository : IRepository<Order, int>
{
    private readonly CrmDbContext _context;

    public OrderRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех заказов с включением связей
    public async Task<List<Order>> GetAsList()
    {
        return await _context.Orders.ToListAsync();
    }

    // Получение заказов с фильтрацией
    public async Task<List<Order>> GetAsList(Func<Order, bool> predicate)
    {
        return await Task.FromResult(_context.Orders
                                              .Where(predicate)
                                              .ToList());
    }

    // Добавление нового заказа
    public async Task Add(Order newRecord)
    {
        await _context.Orders.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление заказа по ключу (ID_Заказа)
    public async Task Delete(int key)
    {
        var order = await _context.Orders.FindAsync(key);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующего заказа
    public async Task Update(Order newValue)
    {
        var order = await _context.Orders.FindAsync(newValue.OrderId);
        if (order != null)
        {
            order.OrderDate = newValue.OrderDate;
            order.OrderAmount = newValue.OrderAmount;
            order.ServiceCount = newValue.ServiceCount;
            order.EmployeeId = newValue.EmployeeId;
            order.ClientId = newValue.ClientId;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
