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
        return Task.FromResult(new List<Ppe>(PpeRecords));
    }

    public Task<List<Ppe>> GetAsList(Func<Ppe, bool> predicate)
    {
        return Task.FromResult(new List<Ppe>(PpeRecords.Where(predicate).ToList()));
    }

    public Task Update(Ppe newValue)
    {
        if(string.IsNullOrWhiteSpace(newValue.Name))
            throw new ArgumentNullException(nameof(newValue.Name));

        var target = PpeRecords.FirstOrDefault(el => el.Name!.CompareTo(newValue.Name) == 0);
        if (target == null)
            throw new InvalidOperationException($"Не найдена запись ppe с переданным ключем: {newValue.Name}");

        PpeRecords.Remove(target);
        PpeRecords.Add(newValue);

        return Task.CompletedTask;
    }
}
