using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class OrdersRepository(DataMock dataMock) : IRepository<Order, int>
{
    private List<Order> Orders { get; set; } = dataMock.Orders;

    public Task Add(Order newRecord)
    {
        if (newRecord.Cost < 1)
            throw new ArgumentException(nameof(newRecord.Cost));

        if(newRecord.CreatedDate == DateTime.MinValue)
            throw new ArgumentException(nameof(newRecord.CreatedDate));

        if (newRecord.NumOfServices < 1)
            throw new ArgumentException(nameof(newRecord.NumOfServices));

        if (newRecord.EmployeeId < 1)
            throw new ArgumentException(nameof(newRecord.NumOfServices));

        if (newRecord.ClientId < 1)
            throw new ArgumentException(nameof(newRecord.NumOfServices));

        var maxId = Orders.Any() ? Orders.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        Orders.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = Orders.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            Orders.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<Order>> GetAsList()
    {
        return Task.FromResult(Orders);
    }

    public Task<List<Order>> GetAsList(Func<Order, bool> predicate)
    {
        return Task.FromResult(Orders.Where(predicate).ToList());
    }

    public Task Update(Order newValue, int key)
    {
        throw new NotImplementedException();
    }
}
