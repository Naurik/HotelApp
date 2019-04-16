using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int HotelId { get; set; }
        public DateTime BeginReserve { get; set; }
        public DateTime EndReserve { get; set; }
    }
}
