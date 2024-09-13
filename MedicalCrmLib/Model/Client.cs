using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Клиент", Schema = "mydb")]
public class Client
{
    [Key]
    [Column("ID_Клиента")]
    [Required]
    public int ClientId { get; set; }  // Первичный ключ

    [Column("Адрес")]
    [StringLength(45)]
    public string? Address { get; set; }  // Адрес клиента

    [Column("Контактный_номер_телефона")]
    [StringLength(45)]
    public string? ContactNumber { get; set; }  // Контактный номер телефона

    [Column("Адрес_электронной_почты")]
    [StringLength(45)]
    public string? Email { get; set; }  // Адрес электронной почты

    [Column("ФИО")]
    [StringLength(45)]
    public string? FullName { get; set; }  // ФИО клиента

    [Column("Дата_рождения")]
    public DateTime? BirthDate { get; set; }  // Дата рождения клиента

    [Column("Пол")]
    [StringLength(45)]
    public string? Gender { get; set; }  // Пол клиента

    [Column("Название_фирмы")]
    [StringLength(45)]
    public string? CompanyName { get; set; }  // Название фирмы клиента
}