using Hotel.Services;
using System;
using System.Data.SqlClient;

namespace Hotel.DataAccess
{
    public class AddRoom:BaseRepository
    {
        public void SaveRoom(Room room)
        {
            string query = @"INSERT INTO Room VALUES
                        (@roomNumber, @beginReserve,@endReserve, @hotelId)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@roomNumber", System.Data.SqlDbType.Int) { Value = room.RoomNumber}, 
                new SqlParameter("@beginReserve", System.Data.SqlDbType.DateTime) { Value = room.BeginReserve},
                new SqlParameter("@endReserve", System.Data.SqlDbType.DateTime) { Value = room.EndReserve},
                new SqlParameter("@hotelId", System.Data.SqlDbType.Int) { Value = room.HotelId}
            });

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public Room GetRoomById(int id, DateTime reserveBegin, DateTime reserveEnd, int numberRoom)
        {
            Room room = new Room();
            string query = "SELECT * FROM Room Where HotelId = @id and " +
                "@numberRoom = NumberRoom and " +
                "((@reserveBegin<BeginReserve and @reserveEnd<BeginReserve) or" +
                "(@reserveBegin>EndReserve and @reserveEnd>EndReserve))";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = id });
                command.Parameters.Add(new SqlParameter("@reserveBegin", System.Data.SqlDbType.DateTime) { Value = reserveBegin });
                command.Parameters.Add(new SqlParameter("@reserveEnd", System.Data.SqlDbType.DateTime) { Value = reserveEnd });
                command.Parameters.Add(new SqlParameter("@numberRoom", System.Data.SqlDbType.Int) { Value = numberRoom });
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    room.HotelId = (int)reader["HotelId"];
                    room.RoomNumber = (int)reader["NumberRoom"];
                    room.BeginReserve = (DateTime)reader["BeginReserve"];
                    room.EndReserve = (DateTime)reader["EndReserve"];
                }
            }
            return room;
        }

       
    }
}
