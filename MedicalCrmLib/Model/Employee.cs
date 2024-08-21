namespace MedicalCrmLib.Model;

public class Employee
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public DateTime DateBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Position { get; set; }
    public string? LaboratoryName { get; set; }
    public string? Login { get; set; }
}
