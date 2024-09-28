using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Заказ", Schema = "mydb")]
public class Order
{
    [Key]
    [Column("ID_Заказа")]
    [Required]
    public int OrderId { get; set; } 

    [Column("Дата_заказа")]
    public DateTime? OrderDate { get; set; }

    [Column("Сумма_заказа")]
    public int? OrderAmount { get; set; }

    [Column("Количество_услуг_в_заказе")]
    public int? ServiceCount { get; set; }

    [Column("Сотрудник_ID")]
    [Required]
    public int EmployeeId { get; set; }

    [Column("Клиент_ID")]
    [Required]
    public int ClientId { get; set; }
}