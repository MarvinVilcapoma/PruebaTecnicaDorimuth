using Common.Base;
using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Model.Request;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implements
{
    public class MoviesService : IMovieInterface
    {
        private readonly ClientDBContext _context; 

        public MoviesService(ClientDBContext context)
        {
            _context = context;
        }

        public List<Movie> GetMovies()
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Movies.Where(x => x.Enabled == true)
                        .Include(x=>x.MovieGenre)
                        .OrderBy(x => x.MovieName).ToList();

                    return query;

                }
            }catch (Exception ex)
            {
                return null;
            }
        }

        public Movie GetMovieById(int ID)
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Movies.Where(x => x.Enabled == true && x.MovieID == ID)
                        .Include(x => x.MovieGenre)
                        .OrderBy(x => x.MovieName).FirstOrDefault();

                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Movie> SearchMovie(SearchMovieRequestV1 requestV1)
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Movies.Where(x => x.Enabled == true)
                        .Include(x => x.MovieGenre)
                        .OrderBy(x => x.MovieName)
                        .AsQueryable();

                    if (!string.IsNullOrEmpty(requestV1.MovieName))
                    {
                        var searchTerm = requestV1.MovieName.Trim().ToLower();

                        query = query.Where(x => x.MovieName.ToLower().Replace(" ", "").Contains(searchTerm));
                    }

                    if (requestV1.MovieGenreID != null && requestV1.MovieGenreID != 0)
                    {
                        query = query.Where(x => x.MovieGenreID == requestV1.MovieGenreID);
                    }

                    return query.ToList();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
