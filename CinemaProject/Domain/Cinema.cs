using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Cinema
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaID { get; set; }
        public string CinemaName { get; set; }
        public int DistrictID {  get; set; }
        public  District District { get; set; }
        public ICollection<CinemaRoom> CinemaRooms { get; set; }
        #region Audit
        public bool Enabled { get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get; set; }
        #endregion

    }
}
