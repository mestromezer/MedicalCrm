using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class LaboratoryRespository(DataMock dataMock) : IRepository<Laboratory, string>
{
    private List<Laboratory> Laboratories = dataMock.Laboratories;

    public Task Add(Laboratory newRecord)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string key)
    {
        var recordToDelete = Laboratories.FirstOrDefault(x => x.Name == key);
        if (recordToDelete != null)
        {
            Laboratories.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<Laboratory>> GetAsList()
    {
        return Task.FromResult(new List<Laboratory>(Laboratories));
    }

    public Task<List<Laboratory>> GetAsList(Func<Laboratory, bool> predicate)
    {
        return Task.FromResult(new List<Laboratory>(Laboratories.Where(predicate).ToList()));
    }

public Task Update(Laboratory newValue)
    {
        throw new NotImplementedException();
    }
}
