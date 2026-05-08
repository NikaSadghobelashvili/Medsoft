namespace Medbay.WinForms.Domain;

public sealed class Patient
{
    public int ID { get; set; }
    public string FullName { get; set; } = "";
    public DateTime Dob { get; set; }
    public int GenderID { get; set; }

    public string? Phone { get; set; }
    public string? Address { get; set; }

    public string? GenderName { get; set; }

    public string? PersonalNumber { get; set; }
    public string? Email { get; set; }
}