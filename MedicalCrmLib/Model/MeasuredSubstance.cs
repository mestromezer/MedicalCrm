using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Измеряемое_вещество", Schema = "mydb")]
public class MeasuredSubstance
{
    [Key]
    [Column("ID_измеряемого_вещества")]
    [Required]
    public int MeasuredSubstanceId { get; set; }  // Первичный ключ

    [Column("Название_измеряемого_вещества")]
    [StringLength(45)]
    public string? Name { get; set; }  // Название вещества

    [Column("Единицы_измерения_измеряемого_вещества")]
    [StringLength(45)]
    public string? MeasurementUnit { get; set; }  // Единицы измерения

    [Column("Референсные_значения_измеряемого_вещества")]
    public int? ReferenceValues { get; set; }  // Референсные значения

    [Column("Возраст_измеряемого_вещества")]
    [StringLength(45)]
    public string? Age { get; set; }  // Возраст вещества

    [Column("Услуга_в_перечне_ID")]
    public int? ServiceListId { get; set; }  // Внешний ключ на Перечень услуг
}