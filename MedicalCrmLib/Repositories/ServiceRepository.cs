using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ServiceRepository : IRepository<Service, int>
{
    private readonly CrmDbContext _context;

    public ServiceRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Service
    public async Task<List<Service>> GetAsList()
    {
        return await _context.Services.ToListAsync();
    }

    // Получение записей Service с фильтром
    public async Task<List<Service>> GetAsList(Func<Service, bool> predicate)
    {
        return await Task.FromResult(_context.Services
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи Service
    public async Task Add(Service newRecord)
    {
        await _context.Services.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Service по ключу (ID_услуги)
    public async Task Delete(int key)
    {
        var service = await _context.Services.FindAsync(key);
        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Service
    public async Task Update(Service newValue)
    {
        var service = await _context.Services.FindAsync(newValue.ServiceId);
        if (service != null)
        {
            service.ServiceTypeId = newValue.ServiceTypeId;
            service.Cost = newValue.Cost;

            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}