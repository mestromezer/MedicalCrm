using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class OrderServiceRepository : IRepository<OrderService, int>
{
    private readonly CrmDbContext _context;

    public OrderServiceRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей OrderService
    public async Task<List<OrderService>> GetAsList()
    {
        return await _context.OrderServices
            .ToListAsync();
    }

    // Получение записей OrderService с фильтром
    public async Task<List<OrderService>> GetAsList(Func<OrderService, bool> predicate)
    {
        return await Task.FromResult(_context.OrderServices
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи OrderService
    public async Task Add(OrderService newRecord)
    {
        await _context.OrderServices.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи OrderService по ключу (Услуги_в_заказе_ID)
    public async Task Delete(int key)
    {
        var orderService = await _context.OrderServices.FindAsync(key);
        if (orderService != null)
        {
            _context.OrderServices.Remove(orderService);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи OrderService
    public async Task Update(OrderService newValue)
    {
        var orderService = await _context.OrderServices.FindAsync(newValue.OrderServiceId);
        if (orderService != null)
        {
            orderService.ServiceListId = newValue.ServiceListId;
            orderService.OrderId = newValue.OrderId;

            _context.OrderServices.Update(orderService);
            await _context.SaveChangesAsync();
        }
    }
}