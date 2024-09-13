using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Лаборатория", Schema = "mydb")]
public class Laboratory
{
    [Key]
    [Column("Название_лаборатории")]
    [Required]
    [StringLength(45)]
    public string LaboratoryName { get; set; }  // Первичный ключ

    [Column("Адрес_лаборатории")]
    [StringLength(45)]
    public string? LaboratoryAddress { get; set; }  // Адрес лаборатории (может быть null)

    [Column("Номер_телефона_лаборатории")]
    [StringLength(45)]
    public string? LaboratoryPhoneNumber { get; set; }  // Номер телефона лаборатории (может быть null)

    [Column("Количество_сотрудников_лаборатории")]
    public int? NumberOfEmployees { get; set; }  // Количество сотрудников лаборатории (может быть null)
}