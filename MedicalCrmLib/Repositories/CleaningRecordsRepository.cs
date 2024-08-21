using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class CleaningRecordsRepository(DataMock dataMock) : IRepository<CleaningRecord, int>
{
    private List<CleaningRecord> CleaningRecords { get; set; } = dataMock.CleaningRecords;

    public Task Add(CleaningRecord newRecord)
    {
        if (newRecord.Cabinet < 1)
            throw new ArgumentException(nameof(newRecord.Cabinet));

        if (newRecord.EmployeeId < 1)
            throw new ArgumentException(nameof(newRecord.EmployeeId));

        var maxId = CleaningRecords.Any() ? CleaningRecords.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        CleaningRecords.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = CleaningRecords.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            CleaningRecords.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<CleaningRecord>> GetAsList()
    {
        return Task.FromResult(CleaningRecords);
    }

    public Task<List<CleaningRecord>> GetAsList(Func<CleaningRecord, bool> predicate)
    {
        return Task.FromResult(CleaningRecords.Where(predicate).ToList());
    }

    public Task Update(CleaningRecord newValue, int key)
    {
        if (key < 0)
            throw new ArgumentNullException(nameof(key));

        var target = CleaningRecords.FirstOrDefault(el => el.Id == key);
        if (target == null)
            throw new InvalidOperationException($"Не найдена запись CleaningRecord с переданным ключем: {key}");

        newValue.Id = key;
        target = newValue;

        return Task.CompletedTask;
    }
}
