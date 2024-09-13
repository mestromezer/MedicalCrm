using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Услуга", Schema = "mydb")]
public class Service
{
    [Key]
    [Column("ID_услуги")]
    [Required]
    public int ServiceId { get; set; }  // Primary Key

    [Column("Вид_услуги_ID_услуги")]
    [Required]
    public int ServiceTypeId { get; set; }  // Foreign Key на таблицу Вид_услуги

    [Column("Стоимость")]
    public decimal? Cost { get; set; }  // Стоимость услуги

    [Column("Название_услуги")]
    [StringLength(45)]
    public string? ServiceName { get; set; }  // Название услуги
}