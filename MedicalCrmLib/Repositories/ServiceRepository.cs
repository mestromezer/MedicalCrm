using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class ServiceRepository(DataMock dataMock) : IRepository<Service, int>
{
    private List<Service> Services = dataMock.Services;

    public Task Add(Service newRecord)
    {
        if (string.IsNullOrWhiteSpace(newRecord.Name))
            throw new ArgumentException(nameof(newRecord.Name));

        if (newRecord.Cost < 1)
            throw new ArgumentException(nameof(newRecord.Cost));

        if (string.IsNullOrWhiteSpace(newRecord.LaboratoryName))
            throw new ArgumentException(nameof(newRecord.LaboratoryName));

        var maxId = Services.Any() ? Services.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        Services.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = Services.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            Services.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<Service>> GetAsList()
    {
        return Task.FromResult(new List<Service>(Services));
    }

    public Task<List<Service>> GetAsList(Func<Service, bool> predicate)
    {
        return Task.FromResult(new List<Service>(Services.Where(predicate).ToList()));
    }

    public Task Update(Service newValue)
    {
        throw new NotImplementedException();
    }
}
