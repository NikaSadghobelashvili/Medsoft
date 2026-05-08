using System.Data;
using Medbay.WinForms.Domain;
using Medbay.WinForms.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Medbay.WinForms.Data;

public sealed class PatientRepository
{
    public List<Patient> List()
    {
        using var con = Database.CreateConnection();
        using var cmd = new SqlCommand("dbo.Patients_List", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();

        using var r = cmd.ExecuteReader();
        var list = new List<Patient>();
        while (r.Read())
        {
            list.Add(new Patient
            {   //GetOrdinal პირდაპირ შესაბამის ინდექსზე დგება იმის და მიხედვით თუ რისი წაკითვხა 
                //გვინდა, მაგას პარამეტრში ვუთითებთ რაც ამარტივებს საქმეს.
                ID = r.GetInt32(r.GetOrdinal("ID")),
                FullName = r.GetString(r.GetOrdinal("FullName")),
                Dob = r.GetDateTime(r.GetOrdinal("Dob")),
                GenderID = r.GetInt32(r.GetOrdinal("GenderID")),
                GenderName = r.GetString(r.GetOrdinal("GenderName")),
                //წაიკითხავს როგორც DbNull თუ არ არის მაშინ წაიკითხავს როგორც string-ს
                Phone = r.IsDBNull(r.GetOrdinal("Phone")) ? null : r.GetString(r.GetOrdinal("Phone")),
                Address = r.IsDBNull(r.GetOrdinal("Address")) ? null : r.GetString(r.GetOrdinal("Address")),
                PersonalNumber = r.IsDBNull(r.GetOrdinal("PersonalNumber")) ? null : r.GetString(r.GetOrdinal("PersonalNumber")),
                Email = r.IsDBNull(r.GetOrdinal("Email")) ? null : r.GetString(r.GetOrdinal("Email"))
            });
        }

        return list;
    }

    public int Insert(Patient p)
    {
        using var con = Database.CreateConnection();
        using var cmd = new SqlCommand("dbo.Patients_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@FullName", p.FullName);
        cmd.Parameters.AddWithValue("@Dob", p.Dob.Date);
        cmd.Parameters.AddWithValue("@GenderID", p.GenderID);
        cmd.Parameters.AddWithValue("@Phone", (object?)p.Phone ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Address", (object?)p.Address ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PersonalNumber", (object?)p.PersonalNumber ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);

        con.Open();
        var obj = cmd.ExecuteScalar();
        return Convert.ToInt32(obj);
    }

    public void Update(Patient p)
    {
        using var con = Database.CreateConnection();
        using var cmd = new SqlCommand("dbo.Patients_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ID", p.ID);
        cmd.Parameters.AddWithValue("@FullName", p.FullName);
        cmd.Parameters.AddWithValue("@Dob", p.Dob.Date);
        cmd.Parameters.AddWithValue("@GenderID", p.GenderID);
        cmd.Parameters.AddWithValue("@Phone", (object?)p.Phone ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Address", (object?)p.Address ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@PersonalNumber", (object?)p.PersonalNumber ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Email", (object?)p.Email ?? DBNull.Value);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var con = Database.CreateConnection();
        using var cmd = new SqlCommand("dbo.Patients_Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", id);

        con.Open();
        cmd.ExecuteNonQuery();
    }
}
