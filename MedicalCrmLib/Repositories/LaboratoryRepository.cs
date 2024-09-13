using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class LaboratoryRepository : IRepository<Laboratory, string>
{
    private readonly CrmDbContext _context;

    public LaboratoryRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Laboratory
    public async Task<List<Laboratory>> GetAsList()
    {
        return await _context.Laboratories.ToListAsync();
    }

    // Получение записей Laboratory с фильтром
    public async Task<List<Laboratory>> GetAsList(Func<Laboratory, bool> predicate)
    {
        return await Task.FromResult(_context.Laboratories.Where(predicate).ToList());
    }

    // Добавление новой записи Laboratory
    public async Task Add(Laboratory newRecord)
    {
        await _context.Laboratories.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Laboratory по ключу (Название_лаборатории)
    public async Task Delete(string key)
    {
        var laboratory = await _context.Laboratories.FindAsync(key);
        if (laboratory != null)
        {
            _context.Laboratories.Remove(laboratory);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Laboratory
    public async Task Update(Laboratory newValue)
    {
        var laboratory = await _context.Laboratories.FindAsync(newValue.LaboratoryName);
        if (laboratory != null)
        {
            laboratory.LaboratoryAddress = newValue.LaboratoryAddress;
            laboratory.LaboratoryPhoneNumber = newValue.LaboratoryPhoneNumber;
            laboratory.NumberOfEmployees = newValue.NumberOfEmployees;

            _context.Laboratories.Update(laboratory);
            await _context.SaveChangesAsync();
        }
    }
}