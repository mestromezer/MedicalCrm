using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Договор", Schema = "mydb")]
public class Contract
{
    [Key]
    [Column("Номер_договора")]
    [Required]
    public int ContractNumber { get; set; }  // Primary Key

    [Column("Дата_заключения_договора")]
    public DateTime? ContractDate { get; set; }  // Дата заключения договора

    [Column("Лаборатория_Название_лаборатории")]
    [Required]
    [StringLength(45)]
    public string LaboratoryName { get; set; }  // Внешний ключ на таблицу Лаборатория

    [Column("Клиент_ID_Клиента")]
    [Required]
    public int ClientId { get; set; }  // Внешний ключ на таблицу Клиент
}