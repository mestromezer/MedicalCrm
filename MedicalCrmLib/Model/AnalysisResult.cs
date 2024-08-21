namespace MedicalCrmLibLib.Model;

public class AnalysisResult
{
    public int Id { get; set; }
    public int AnalysisId { get; set; }
    public int EmployeeId { get; set; }
    public string? Report { get; set; }
    public string? Comments { get; set; }
}
