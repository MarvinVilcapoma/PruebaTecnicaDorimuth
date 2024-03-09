using Domain;
using Infraestructure.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implements
{
    public class MovieGenreService : IMovieGenreInterface
    {
        private readonly ClientDBContext _context;

        public MovieGenreService(ClientDBContext context)
        {
            _context = context;
        }

        public List<MovieGenre> GetMovieGenres()
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.MovieGenres.Where(x => x.Enabled == true).OrderBy(x => x.MovieGenreName).ToList();

                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
