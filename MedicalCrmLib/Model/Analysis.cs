namespace MedicalCrmLib.Model;

public class Analysis
{
    public int Id { get; set; }
    public DateTime DateOfSample { get; set; }
    public string? BioMaterialType { get; set; }
    public int OrderId { get; set; }
}
