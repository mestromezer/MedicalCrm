using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Результаты_анализа_измеряемого_вещества", Schema = "mydb")]
public class AnalysisResult
{
    [Key]
    [Column("Измеряемое_вещество_ID_измеряемого_вещества", Order = 0)]
    [Required]
    public int MeasuredSubstanceId { get; set; }  // Часть составного первичного ключа

    [Key]
    [Column("Анализ_Код_анализа", Order = 1)]
    [Required]
    public int AnalysisCode { get; set; }  // Часть составного первичного ключа

    [Key]
    [Column("Сотрудник_ID_Сотрудника", Order = 2)]
    [Required]
    public int EmployeeId { get; set; }  // Часть составного первичного ключа

    [Column("Результаты_анализа")]
    [StringLength(45)]
    public string? AnalysisResultText { get; set; }  // Результаты анализа

    [Column("Дополнительный_комментарий_врача")]
    [StringLength(45)]
    public string? DoctorComment { get; set; }  // Дополнительный комментарий врача
}