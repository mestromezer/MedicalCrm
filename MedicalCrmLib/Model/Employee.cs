using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCrmLib.Model;

[Table("Сотрудник", Schema = "mydb")]
public class Employee
{
    [Key]
    [Column("ID_Сотрудника")]
    [Required]
    public int EmployeeId { get; set; }  // Первичный ключ

    [Column("ФИО_сотрудника_лаборатории")]
    [StringLength(45)]
    public string? FullName { get; set; }  // Полное имя сотрудника

    [Column("Дата_рождения")]
    public DateTime? BirthDate { get; set; }  // Дата рождения сотрудника

    [Column("Номер_контактного_телефона")]
    [StringLength(45)]
    public string? PhoneNumber { get; set; }  // Контактный номер телефона

    [Column("Должность_в_лаборатории")]
    [StringLength(45)]
    public string? Position { get; set; }  // Должность сотрудника

    [Column("Лаборатория_Название_лаборатории")]
    [Required]
    [StringLength(45)]
    public string LaboratoryName { get; set; }  // Внешний ключ на таблицу Лаборатория

    [Column("Аккаунт_Логин")]
    [Required]
    [StringLength(45)]
    public string AccountLogin { get; set; }  // Внешний ключ на таблицу Аккаунт

    [ForeignKey("AccountLogin")]
    public Account? Account { get; set; }  // Связь с аккаунтом
}