using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("График_уборки", Schema = "mydb")]
public class CleaningSchedule
{
    [Key]
    [Column("Номер_кабинета", Order = 0)]
    [Required]
    public int RoomNumber { get; set; }  // Primary Key - часть составного ключа

    [Key]
    [Column("Дата_проведения_уборки", Order = 1)]
    [Required]
    public DateTime CleaningDate { get; set; }  // Primary Key - часть составного ключа

    [Column("Сотрудник_ID_Сотрудника")]
    [Required]
    public int EmployeeId { get; set; }  // Внешний ключ на таблицу Сотрудник
}