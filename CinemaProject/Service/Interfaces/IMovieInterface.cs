using Domain;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IMovieInterface
    {
        public List<Movie> GetMovies();

        public Movie GetMovieById(int ID);

        public List<Movie> SearchMovie(SearchMovieRequestV1 requestV1);


    }
}
