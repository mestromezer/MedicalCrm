using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Анализ", Schema = "mydb")]
public class Analysis
{
    [Key]
    [Column("Код_анализа")]
    [Required]
    public int AnalysisCode { get; set; }

    [Column("Дата_забора")]
    public DateTime? SampleDate { get; set; }

    [Column("Вид_биоматериала")]
    [StringLength(45)]
    public string? BiomaterialType { get; set; }

    [Column("Заказ_ID_Заказа")]
    public int OrderId { get; set; }
}