using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    //DISTRITO
    public class District
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictID { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string DistrictName { get; set; }

        #region Audit
        public bool Enabled {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get;set; }
        #endregion

    }
}
