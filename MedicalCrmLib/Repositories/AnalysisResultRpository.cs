using MedicalCrmLib.Interfaces;
using MedicalCrmLib.Model;

namespace MedicalCrmLib.Repositories;

public class AnalysisResultRpository(DataMock dataMock) : IRepository<AnalysisResult, int>
{
    private List<AnalysisResult> AnalysisResults = dataMock.AnalysisesResults;

    public Task Add(AnalysisResult newRecord)
    {
        if (newRecord.AnalysisId < 1)
            throw new ArgumentException(nameof(newRecord.AnalysisId));

        if (newRecord.EmployeeId < 1)
            throw new ArgumentException(nameof(newRecord.EmployeeId));

        var maxId = AnalysisResults.Any() ? AnalysisResults.Max(x => x.Id) : 0;
        newRecord.Id = maxId + 1;
        AnalysisResults.Add(newRecord);

        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var recordToDelete = AnalysisResults.FirstOrDefault(x => x.Id == key);
        if (recordToDelete != null)
        {
            AnalysisResults.Remove(recordToDelete);
        }

        return Task.CompletedTask;
    }

    public Task<List<AnalysisResult>> GetAsList()
    {
        return Task.FromResult(AnalysisResults);
    }

    public Task<List<AnalysisResult>> GetAsList(Func<AnalysisResult, bool> predicate)
    {
        return Task.FromResult(AnalysisResults.Where(predicate).ToList());
    }

    public Task Update(AnalysisResult newValue, int key)
    {
        throw new NotImplementedException();
    }
}
