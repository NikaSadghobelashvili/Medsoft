using System.Text.RegularExpressions;
using Medbay.WinForms.Data;
using Medbay.WinForms.Domain;

namespace Medbay.WinForms.Application;

public sealed class PatientService
{
    private readonly PatientRepository _patients = new();

    public List<Patient> List() => _patients.List();

    public int Add(Patient p)
    {
        NormalizeAndValidate(p);
        return _patients.Insert(p);
    }

    public void Edit(Patient p)
    {
        NormalizeAndValidate(p);
        _patients.Update(p);
    }

    public void Delete(int id) => _patients.Delete(id);

    private static void NormalizeAndValidate(Patient p)
    {
        if (string.IsNullOrWhiteSpace(p.FullName))
            throw new ArgumentException("გთხოვთ შეავსოთ პაციენტის სახელი და გვარი.");

        if (p.Dob == default)
            throw new ArgumentException("გთხოვთ მიუთითოთ დაბადების თარიღი.");

        if (p.GenderID <= 0)
            throw new ArgumentException("გთხოვთ აირჩიოთ სქესი.");

        p.Phone = NormalizePhone(p.Phone);
        if (!string.IsNullOrWhiteSpace(p.Phone))
        {
            // მოთხოვნა: 5-ით იწყებოდეს და იყოს 9 ციფრი
            if (!Regex.IsMatch(p.Phone, "^5\\d{8}$"))
                throw new ArgumentException("ტელეფონის ნომერი უნდა იწყებოდეს 5-ით და იყოს 9 ციფრი.");
        }

        if (string.IsNullOrWhiteSpace(p.Address))
            p.Address = null;
    }

    private static string? NormalizePhone(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return null;

        var digitsOnly = Regex.Replace(phone, "\\D", "");  
        return string.IsNullOrWhiteSpace(digitsOnly) ? null : digitsOnly;
    }
}
