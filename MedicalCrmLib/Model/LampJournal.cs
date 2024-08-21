namespace MedicalCrmLibLib.Model;

public class LampJournal
{
    public int Id { get; set; }
    public DateTime RecordDateTime { get; set; }
    public int EmployeeId { get; set; }
    public int Cabinet { get; set; }
    public DateTime ProductionTime { get; set; }
    public DateTime BestBeforeDate { get; set; }
}
