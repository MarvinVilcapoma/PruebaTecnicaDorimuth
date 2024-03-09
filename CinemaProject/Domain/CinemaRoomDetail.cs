using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class CinemaRoomDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaRoomDetailID { get; set; }
        public int TicketsAvailable { get; set; }
        public int CinemaRoomID {  get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        #region Audit
        public bool Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        #endregion
    }
}
