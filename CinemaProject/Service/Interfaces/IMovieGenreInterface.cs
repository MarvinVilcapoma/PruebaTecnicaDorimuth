using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IMovieGenreInterface
    {
        public List<MovieGenre> GetMovieGenres();
    }
}
