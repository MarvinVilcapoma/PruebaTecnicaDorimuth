using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class SearchMovieRequestV1
    {
        public string MovieName { get; set; }
        public int MovieGenreID {  get; set; }
    }
}
