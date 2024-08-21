﻿namespace MedicalCrmLib.Model;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
}
