using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Услуги_в_заказе", Schema = "mydb")]
public class OrderService
{
    [Key]
    [Column("Услуги_в_заказе_ID")]
    [Required]
    public int OrderServiceId { get; set; }

    [Column("Перечень_оказываемых_услуг_ID_услуги_в_перечне")]
    [Required]
    public int ServiceListId { get; set; }

    [Column("Заказ_ID_Заказа")]
    [Required]
    public int OrderId { get; set; }
}