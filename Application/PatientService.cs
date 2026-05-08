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

        p.Phone = NormalizeDigitsOnly(p.Phone);
        if (!string.IsNullOrWhiteSpace(p.Phone))
        {
            // მოთხოვნა: 5-ით იწყებოდეს და იყოს 9 ციფრი
            if (!Regex.IsMatch(p.Phone, "^5\\d{8}$"))
                throw new ArgumentException("ტელეფონის ნომერი უნდა იწყებოდეს 5-ით და იყოს 9 ციფრი.");
        }

        if (string.IsNullOrWhiteSpace(p.Address))
            p.Address = null;

        p.PersonalNumber = NormalizeDigitsOnly(p.PersonalNumber);
        if (!string.IsNullOrWhiteSpace(p.PersonalNumber))
        {
            if (p.PersonalNumber.Length != 11)
                throw new ArgumentException("პირადი ნომერი უნდა იყოს 11-ნიშნა.");
        }

        p.Email = NormalizeEmail(p.Email);
        if (!string.IsNullOrWhiteSpace(p.Email) && !p.Email.Contains('@'))
            throw new ArgumentException("ელ-ფოსტა უნდა შეიცავდეს @ სიმბოლოს.");
    }

    private static string? NormalizeDigitsOnly(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;

        var digitsOnly = Regex.Replace(value, "\\D", "");  
        return string.IsNullOrWhiteSpace(digitsOnly) ? null : digitsOnly;
    }

    private static string? NormalizeEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return null;
        return email.Trim();
    }
}
