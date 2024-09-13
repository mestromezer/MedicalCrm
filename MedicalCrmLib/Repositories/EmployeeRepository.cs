using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class EmployeeRepository : IRepository<Employee, int>
{
    private readonly CrmDbContext _context;

    public EmployeeRepository(CrmDbContext context)
    {
        _context = context;
    }

    // Получение всех записей Employee
    public async Task<List<Employee>> GetAsList()
    {
        return await _context.Employees
            .Include(e => e.Account)     // Включаем связанный аккаунт
            .ToListAsync();
    }

    // Получение записей Employee с фильтром
    public async Task<List<Employee>> GetAsList(Func<Employee, bool> predicate)
    {
        return await Task.FromResult(_context.Employees
            .Include(e => e.Account)
            .Where(predicate)
            .ToList());
    }

    // Добавление новой записи Employee
    public async Task Add(Employee newRecord)
    {
        await _context.Employees.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    // Удаление записи Employee по ключу (ID_Сотрудника)
    public async Task Delete(int key)
    {
        var employee = await _context.Employees.FindAsync(key);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }

    // Обновление существующей записи Employee
    public async Task Update(Employee newValue)
    {
        var employee = await _context.Employees.FindAsync(newValue.EmployeeId);
        if (employee != null)
        {
            employee.FullName = newValue.FullName;
            employee.BirthDate = newValue.BirthDate;
            employee.PhoneNumber = newValue.PhoneNumber;
            employee.Position = newValue.Position;
            employee.LaboratoryName = newValue.LaboratoryName;
            employee.AccountLogin = newValue.AccountLogin;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}