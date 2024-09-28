using MedicalCrmLib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Repositories;

public class AnalysisResultRepository : IRepository<AnalysisResult, (int MeasuredSubstanceId, int AnalysisCode, int EmployeeId)>
{
    private readonly CrmDbContext _context;

    public AnalysisResultRepository(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<List<AnalysisResult>> GetAsList()
    {
        return await _context.AnalysisResults
            .ToListAsync();
    }

    public async Task<List<AnalysisResult>> GetAsList(Func<AnalysisResult, bool> predicate)
    {
        return await Task.FromResult(_context.AnalysisResults
            .Where(predicate)
            .ToList());
    }

    public async Task Add(AnalysisResult newRecord)
    {
        await _context.AnalysisResults.AddAsync(newRecord);
        await _context.SaveChangesAsync();
    }

    public async Task Delete((int MeasuredSubstanceId, int AnalysisCode, int EmployeeId) key)
    {
        var analysisResult = await _context.AnalysisResults.FindAsync(key.MeasuredSubstanceId, key.AnalysisCode, key.EmployeeId);
        if (analysisResult != null)
        {
            _context.AnalysisResults.Remove(analysisResult);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(AnalysisResult newValue)
    {
        var analysisResult = await _context.AnalysisResults.FindAsync(newValue.MeasuredSubstanceId, newValue.AnalysisCode, newValue.EmployeeId);
        if (analysisResult != null)
        {
            analysisResult.AnalysisResultText = newValue.AnalysisResultText;
            analysisResult.DoctorComment = newValue.DoctorComment;

            _context.AnalysisResults.Update(analysisResult);
            await _context.SaveChangesAsync();
        }
    }
}