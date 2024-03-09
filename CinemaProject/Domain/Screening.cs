using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    //FUNCIÓN
    public class Screening
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScreeningID {  get; set; }
        public int MovieID {  get; set; }
        public Movie Movie { get; set; }
        public int CinemaRoomID {  get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public DateTime? StartDateScreening { get; set; }
        public DateTime? EndDateScreening { get; set; }
        #region Audit
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Enabled {  get; set; }
        #endregion
    }
}
