using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCrmLib.Model;

[Table("Аккаунт", Schema = "mydb")]
public class Account
{
    [Key]
    [Column("Логин")]
    [Required]
    [StringLength(45)]
    public string Login { get; set; } = null!;

    [Column("Пароль")]
    [StringLength(45)]
    public string? Password { get; set; }

    [Column("Должность_пользователя")]
    [StringLength(45)]
    public string? UserRole { get; set; }
}