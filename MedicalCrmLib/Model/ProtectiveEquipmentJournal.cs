using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(EquipmentName), nameof(EmployeeId))]
[Table("Журнал_СИЗ", Schema = "mydb")]
public class ProtectiveEquipmentJournal
{
    [Column("Наименование_СИЗ", Order = 0)]
    [Required]
    [StringLength(45)]
    public string EquipmentName { get; set; }  // Наименование СИЗ (часть составного ключа)

    [Column("Количество_СИЗов")]
    public int? EquipmentCount { get; set; }  // Количество СИЗов

    [Column("Сотрудник_ID_Сотрудника", Order = 1)]
    [Required]
    public int EmployeeId { get; set; }  // Внешний ключ на таблицу Сотрудник (часть составного ключа)

    [Column("Необходимое_количество_СИЗов")]
    public int? RequiredEquipmentCount { get; set; }  // Необходимое количество СИЗов
}