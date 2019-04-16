using Hotel.Services;
using System.Data.SqlClient;

namespace Hotel.DataAccess
{
    public class AddUser : BaseRepository
    {
        public void SavePerson(Users user)
        {
            string query = @"INSERT INTO UsersDB(Login, Number, Email) VALUES(@log, @number, @email)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@log", System.Data.SqlDbType.NVarChar) { Value = user.Login},
                new SqlParameter("@number", System.Data.SqlDbType.NVarChar) { Value = user.PhoneNumber},
                new SqlParameter("@email", System.Data.SqlDbType.NVarChar) { Value = user.Email}
            });

            command.ExecuteNonQuery();
            command.Dispose();
        }
        public Users GetUserByLog(string login)
        {
            Users p = null;
            string query = "SELECT * FROM UsersDB Where Login = @log";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.Add(new SqlParameter("@log", System.Data.SqlDbType.NVarChar) { Value = login });
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new Users();
                        reader.Read();
                        p.Login = reader["Login"].ToString();
                        p.Email = reader["Email"].ToString();
                        p.PhoneNumber = reader["Number"].ToString();
                    }
                }
            }
            return p;
        }
    }
}