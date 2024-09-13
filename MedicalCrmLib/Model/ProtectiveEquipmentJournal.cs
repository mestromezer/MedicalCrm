using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Журнал_СИЗ", Schema = "mydb")]
public class ProtectiveEquipmentJournal
{
    [Key]
    [Column("Наименование_СИЗ", Order = 0)]
    [Required]
    [StringLength(45)]
    public string EquipmentName { get; set; }  // Наименование СИЗ (часть составного ключа)

    [Column("Количество_СИЗов")]
    public int? EquipmentCount { get; set; }  // Количество СИЗов

    [Key]
    [Column("Сотрудник_ID_Сотрудника", Order = 1)]
    [Required]
    public int EmployeeId { get; set; }  // Внешний ключ на таблицу Сотрудник (часть составного ключа)

    [Column("Необходимое_количество_СИЗов")]
    public int? RequiredEquipmentCount { get; set; }  // Необходимое количество СИЗов
}