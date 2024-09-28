using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class EmployeeRepository(CrmDbContext context) : IRepository<Employee, int>
{
    public async Task<List<Employee>> GetAsList()
    {
        return await context.Employees
            .Include(e => e.Account) 
            .ToListAsync();
    }

    public async Task<List<Employee>> GetAsList(Func<Employee, bool> predicate)
    {
        return await Task.FromResult(context.Employees
            .Include(e => e.Account)
            .Where(predicate)
            .ToList());
    }

    public async Task Add(Employee newRecord)
    {
        await context.Employees.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var employee = await context.Employees.FindAsync(key);
        if (employee != null)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Employee newValue)
    {
        var employee = await context.Employees.FindAsync(newValue.EmployeeId);
        if (employee != null)
        {
            employee.FullName = newValue.FullName;
            employee.BirthDate = newValue.BirthDate;
            employee.PhoneNumber = newValue.PhoneNumber;
            employee.Position = newValue.Position;
            employee.LaboratoryName = newValue.LaboratoryName;
            employee.AccountLogin = newValue.AccountLogin;

            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }
    }
}