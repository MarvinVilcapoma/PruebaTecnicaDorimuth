using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class CinemaRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaRoomID {  get; set; }

        [Column(TypeName = "varchar(200)")]
        public string CinemaRoomName { get; set;}
        public int Capacity {  get; set;}
        public int CinemaID { get; set;}
        public Cinema Cinema {  get; set;}

        #region Audit
        public bool Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        #endregion
    }
}
