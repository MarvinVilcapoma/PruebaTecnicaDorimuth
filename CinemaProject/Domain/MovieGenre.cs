using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    //GÉNERO DE PELICULA
    public class MovieGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieGenreID {  get; set; }
        [Column(TypeName = "varchar(max)")]
        public string MovieGenreName {  get; set; }

        #region Audit
        public bool Enabled {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        #endregion

    }
}
