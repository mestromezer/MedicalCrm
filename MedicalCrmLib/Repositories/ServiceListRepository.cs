using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class ServiceListRepository : IRepository<ServiceList, int>
{
    private readonly CrmDbContext _context;

    public ServiceListRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей ServiceList
    public async Task<List<ServiceList>> GetAsList()
    {
        return await _context.ServiceListRecords
            .ToListAsync();
    }

    // Получение записей ServiceList с фильтром
    public async Task<List<ServiceList>> GetAsList(Func<ServiceList, bool> predicate)
    {
        return await Task.FromResult(_context.ServiceListRecords
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи ServiceList
    public async Task Add(ServiceList newRecord)
    {
        await _context.ServiceListRecords.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи ServiceList по ключу (ID_услуги_в_перечне)
    public async Task Delete(int key)
    {
        var serviceList = await _context.ServiceListRecords.FindAsync(key);
        if (serviceList != null)
        {
            _context.ServiceListRecords.Remove(serviceList);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи ServiceList
    public async Task Update(ServiceList newValue)
    {
        var serviceList = await _context.ServiceListRecords.FindAsync(newValue.ServiceListId);
        if (serviceList != null)
        {
            serviceList.ServicePrice = newValue.ServicePrice;
            serviceList.ServiceName = newValue.ServiceName;
            serviceList.LaboratoryName = newValue.LaboratoryName;

            _context.ServiceListRecords.Update(serviceList);
            await _context.SaveChangesAsync();
        }
    }
}