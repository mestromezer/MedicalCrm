using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class LampJournalRepository(DataMock dataMock) : IRepository<LampJournal, int>
{
    private List<LampJournal> LampJournalRcords = dataMock.LampJournalRecords;

    public Task Add(LampJournal newRecord)
    {
        if (newRecord.Cabinet < 1)
            throw new ArgumentException(nameof(newRecord.Cabinet));

        if (newRecord.EmployeeId < 1)
            throw new ArgumentException(nameof(newRecord.EmployeeId));

        if(newRecord.ProductionTime == DateTime.MinValue)
            throw new ArgumentException(nameof(newRecord.ProductionTime));

        if (newRecord.BestBeforeDate == DateTime.MinValue)
            throw new ArgumentException(nameof(newRecord.BestBeforeDate));

        if (newRecord.RecordDateTime == DateTime.MinValue)
            throw new ArgumentException(nameof(newRecord.RecordDateTime));

        var maxId = LampJournalRcords.Any() ? LampJournalRcords.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        LampJournalRcords.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = LampJournalRcords.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            LampJournalRcords.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<LampJournal>> GetAsList()
    {
        return Task.FromResult(LampJournalRcords);
    }

    public Task<List<LampJournal>> GetAsList(Func<LampJournal, bool> predicate)
    {
        return Task.FromResult(LampJournalRcords.Where(predicate).ToList());
    }

    public Task Update(LampJournal newValue, int key)
    {
        throw new NotImplementedException();
    }
}
