using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess
{
    public class Repository
    {
        public void SavePerson(User users)
        {
            string query = @"INSERT INTO Users VALUES(@lastName,@firstName,@midleName, @genderId)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@lastName", System.Data.SqlDbType.NVarChar) { Value = users.Login},
                new SqlParameter("@firstName", System.Data.SqlDbType.NVarChar) { Value = users.Password},
                new SqlParameter("@midleName", System.Data.SqlDbType.NVarChar) { Value = users.PhoneNumber},
                new SqlParameter("@genderId", System.Data.SqlDbType.Int) { Value = users.Email}
            });

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void SaveJournal(Hotels hotels)
        {
            string query = @"INSERT INTO Journal VALUES(@personId,@subjectId,@mark, @createDate)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = hotels.Name},
                new SqlParameter("@roomNumber", System.Data.SqlDbType.Int) { Value = hotels.RoomNumber},
                new SqlParameter("@reservationDate", System.Data.SqlDbType.DateTime) { Value = hotels.ReservationForDate},
                new SqlParameter("@idUser", System.Data.SqlDbType.Int) { Value = hotels.UserId}
            });

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public Person GetPersonById(int id)
        {
            Person p = new Person();
            string query = "SELECT * FROM Person Where Id = @id";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = id });
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    p.ID = (int)reader["Id"];
                    p.LastName = reader["LastName"].ToString();
                    p.FirstName = reader["FirstName"].ToString();
                    p.MiddleName = reader["MidleName"].ToString();
                    p.GenderId = (int)reader["GenderId"];
                }
            }
            return p;
        }
    }
}
