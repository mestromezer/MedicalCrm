using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Журнал", Schema = "mydb")]
public class Journal
{
    [Key]
    [Column("ID_Журнала", Order = 0)]
    [Required]
    public int JournalId { get; set; }  // Primary Key - часть составного ключа

    [Key]
    [Column("Дата", Order = 1)]
    [Required]
    public DateTime Date { get; set; }  // Primary Key - часть составного ключа

    [Column("Сотрудник_ID_Сотрудника")]
    [Required]
    public int EmployeeId { get; set; }  // Внешний ключ на таблицу Сотрудник

    [Column("Номер_кабинета")]
    public int? RoomNumber { get; set; }  // Номер кабинета

    [Column("Дата_изготовления")]
    public DateTime? ManufactureDate { get; set; }  // Дата изготовления

    [Column("Срок_использования")]
    public DateTime? ExpiryDate { get; set; }  // Срок использования
}