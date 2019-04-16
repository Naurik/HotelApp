using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess
{
    public class AddHotel:BaseRepository
    {
        public void SaveHotel(Hotels hotel)
        {
            string query = @"INSERT INTO Hotel VALUES(@name)";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = hotel.Name}
                });

            command.ExecuteNonQuery();
            command.Dispose();
        }

        //public Hotels Choice(string Name)
        //{
        //    User p = new User();
        //    string query = "SELECT * FROM Hotel Where Name = @name";
        //    using (SqlCommand command = new SqlCommand(query, _connection))
        //    {
        //        command.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = login });
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            reader.Read();
        //            p.Login = reader["Login"].ToString();
        //            p.PhoneNumber = reader["Number"].ToString();
        //            p.Email = reader["Email"].ToString();
        //        }
        //    }
        //    return p;
        //}
    }
}
