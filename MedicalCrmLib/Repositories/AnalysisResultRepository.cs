using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AnalysisResultRepository(CrmDbContext context)
    : IRepository<AnalysisResult, (int MeasuredSubstanceId, int AnalysisCode, int EmployeeId)>
{
    public async Task<List<AnalysisResult>> GetAsList()
    {
        return await context.AnalysisResults
            .ToListAsync();
    }

    public async Task<List<AnalysisResult>> GetAsList(Func<AnalysisResult, bool> predicate)
    {
        return await Task.FromResult(context.AnalysisResults
            .Where(predicate)
            .ToList());
    }

    public async Task Add(AnalysisResult newRecord)
    {
        await context.AnalysisResults.AddAsync(newRecord);
        await context.SaveChangesAsync();
    }

    public async Task Delete((int MeasuredSubstanceId, int AnalysisCode, int EmployeeId) key)
    {
        var analysisResult = await context.AnalysisResults.FindAsync(key.MeasuredSubstanceId, key.AnalysisCode, key.EmployeeId);
        if (analysisResult != null)
        {
            context.AnalysisResults.Remove(analysisResult);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(AnalysisResult newValue)
    {
        var analysisResult = await context.AnalysisResults.FindAsync(newValue.MeasuredSubstanceId, newValue.AnalysisCode, newValue.EmployeeId);
        if (analysisResult != null)
        {
            analysisResult.AnalysisResultText = newValue.AnalysisResultText;
            analysisResult.DoctorComment = newValue.DoctorComment;

            context.AnalysisResults.Update(analysisResult);
            await context.SaveChangesAsync();
        }
    }
}