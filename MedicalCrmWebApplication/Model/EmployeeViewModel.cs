using System.ComponentModel.DataAnnotations;

namespace MedicalCrmWebApplication.Model;

public class EmployeeViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Некорректное ФИО")]
    public string? FullName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Некорректная дата рождения")]
    public string? BirthDate { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Некорректный контактный номер")]
    public string? PhoneNumber { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Некорректное имя лаборатории")]
    public string? LaboratoryName { get; set; }
}