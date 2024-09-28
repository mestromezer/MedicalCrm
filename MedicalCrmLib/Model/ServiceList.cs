using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Перечень_оказываемых_услуг", Schema = "mydb")]
public class ServiceList
{
    [Key]
    [Column("ID_услуги_в_перечне")]
    [Required]
    public int ServiceListId { get; set; }

    [Column("Цена_оказываемой_услуги")]
    public int? ServicePrice { get; set; }

    [Column("Лаборатория_Название_лаборатории")]
    [Required]
    [StringLength(45)]
    public string LaboratoryName { get; set; }

    [Column("Название_услуги")]
    [StringLength(45)]
    public string? ServiceName { get; set; }
}