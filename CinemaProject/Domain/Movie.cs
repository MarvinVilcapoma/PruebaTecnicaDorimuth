using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    //PELÍCULA
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID {  get; set; }
        [Column(TypeName = "varchar(max)")]
        public string MovieName { get; set; }
        public int MovieGenreID { get; set; }
        public MovieGenre MovieGenre { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Synopsis {  get; set; }
        public int Duration { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string ImgURLOrBase64 {  get; set; }

        #region Audit
        public bool Enabled { get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdateDate {  get; set; }
        #endregion
    }
}
