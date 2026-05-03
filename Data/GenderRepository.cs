using Medbay.WinForms.Domain;
using Medbay.WinForms.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Medbay.WinForms.Data;

public sealed class GenderRepository
{
    public List<Gender> List()
    {
        //con ავტომატურად დაიკეტება რადგან .net 8 ში შეგვიძლია using პირდაპირ ამ ცვლადებს მოვსდოთ
        //არასაჭირო bracket-ების გარეშე
        using var con = Database.CreateConnection();
        using var cmd = new SqlCommand("SELECT GenderID, GenderName FROM dbo.Gender ORDER BY GenderID;", con);
        con.Open();

        using var r = cmd.ExecuteReader();
        var list = new List<Gender>();
        while (r.Read())
        {
            list.Add(new Gender
            {
                GenderID = r.GetInt32(0),
                GenderName = r.GetString(1),
            });
        }

        return list;
    }
}
