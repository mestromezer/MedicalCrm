using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Заказ", Schema = "mydb")]
public class Order
{
    [Key]
    [Column("ID_Заказа")]
    [Required]
    public int OrderId { get; set; }  // Primary Key

    [Column("Дата_заказа")]
    public DateTime? OrderDate { get; set; }  // Дата заказа

    [Column("Сумма_заказа")]
    public int? OrderAmount { get; set; }  // Сумма заказа

    [Column("Количество_услуг_в_заказе")]
    public int? ServiceCount { get; set; }  // Количество услуг в заказе

    [Column("Сотрудник_ID")]
    [Required]
    public int EmployeeId { get; set; }  // Внешний ключ на таблицу Сотрудник

    [Column("Клиент_ID")]
    [Required]
    public int ClientId { get; set; }  // Внешний ключ на таблицу Клиент
}