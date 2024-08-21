namespace MedicalCrmLibLib.Model;

public class MeasuredSubstance
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UnitsOfMeasurement { get; set; }
    public int ReferenceValues { get; set; }
    public string? Age { get; set; }
    public int ServiceId { get; set; }
}
