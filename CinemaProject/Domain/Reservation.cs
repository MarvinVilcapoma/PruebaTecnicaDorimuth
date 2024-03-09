using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ReservationID { get; set; }
        public string Names {  get; set; }
        public string LastNames { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public int CinemaRoomID { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public int MovieID {  get; set; }
        public Movie Movie { get; set; }
        #region Audit
        public bool Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        #endregion
    }
}
