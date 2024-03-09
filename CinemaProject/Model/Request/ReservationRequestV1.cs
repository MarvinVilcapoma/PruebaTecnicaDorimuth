using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class ReservationRequestV1
    {
        public int ReservationID { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public int CinemaRoomID { get; set; }
        public int MovieID { get; set; }
        public bool Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
