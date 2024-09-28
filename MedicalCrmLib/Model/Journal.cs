using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MedicalCrmLib.Model;

[PrimaryKey(nameof(JournalId), nameof(Date))]
[Table("Журнал", Schema = "mydb")]
public class Journal
{
    [Column("ID_Журнала", Order = 0)]
    [Required]
    public int JournalId { get; set; }

    [Column("Дата", Order = 1)]
    [Required]
    public DateTime Date { get; set; } 

    [Column("Сотрудник_ID_Сотрудника")]
    [Required]
    public int EmployeeId { get; set; }

    [Column("Номер_кабинета")]
    public int? RoomNumber { get; set; }

    [Column("Дата_изготовления")]
    public DateTime? ManufactureDate { get; set; }

    [Column("Срок_использования")]
    public DateTime? ExpiryDate { get; set; }
}