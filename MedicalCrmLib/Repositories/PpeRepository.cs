using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class PpeRepository(DataMock dataMock) : IRepository<Ppe, string>
{
    private List<Ppe> PpeRecords = dataMock.PersonlaProtectiveEquipment;
    public Task Add(Ppe newRecord)
    {
        if (string.IsNullOrWhiteSpace(newRecord.Name))
            throw new ArgumentNullException(nameof(newRecord.Name));

        if (newRecord.RequiredQuantity < 1)
            throw new ArgumentException(nameof(newRecord.RequiredQuantity));

        if (newRecord.EmployeeId < 1)
            throw new ArgumentException(nameof(newRecord.EmployeeId));

        PpeRecords.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(string key)
    {
        var recordToDelete = PpeRecords.FirstOrDefault(x => x.Name == key);
        if (recordToDelete != null)
        {
            PpeRecords.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<Ppe>> GetAsList()
    {
        return Task.FromResult(PpeRecords);
    }

    public Task<List<Ppe>> GetAsList(Func<Ppe, bool> predicate)
    {
        return Task.FromResult(PpeRecords.Where(predicate).ToList());
    }

    public Task Update(Ppe newValue, string key)
    {
        if(string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var target = PpeRecords.FirstOrDefault(el => el.Name!.CompareTo(key) == 0);
        if (target == null)
            throw new InvalidOperationException($"Не найдена запись ppe с переданным ключем: {key}");

        newValue.Name = key;
        target = newValue;

        return Task.CompletedTask;
    }
}
