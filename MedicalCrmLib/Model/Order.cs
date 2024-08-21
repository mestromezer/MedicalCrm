namespace MedicalCrmLib.Model;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Cost { get; set; }
    public int NumOfServices { get; set; }
    public int EmployeeId { get; set; }
    public int ClientId { get; set; }
}
