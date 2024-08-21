using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;
using System.Linq;

namespace MedicalCrmLib.Repositories;

public class ClientRepostiory(DataMock dataMock) : IRepository<Client, int>
{
    private List<Client> Clients = dataMock.Clients;
    public Task Add(Client newRecord)
    {
        if (string.IsNullOrWhiteSpace(newRecord.FullName))
            throw new ArgumentException(nameof(newRecord.FullName));


        if (string.IsNullOrWhiteSpace(newRecord.Email))
            throw new ArgumentException(nameof(newRecord.Email));

        var maxId = Clients.Any() ? Clients.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        Clients.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = Clients.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            Clients.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<Client>> GetAsList()
    {
        return Task.FromResult(Clients);
    }

    public Task<List<Client>> GetAsList(Func<Client, bool> predicate)
    {
        return Task.FromResult(Clients.Where(predicate).ToList());
    }

    public Task Update(Client newValue, int key)
    {
        throw new NotImplementedException();
    }
}
