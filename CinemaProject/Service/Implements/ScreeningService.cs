using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implements
{
    public class ScreeningService : IScreeningInterface
    {
        private readonly ClientDBContext _context;

        public ScreeningService(ClientDBContext context)
        {
            _context = context;
        }
        public List<Screening> GetScreenings()
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Screenings.Where(x => x.Enabled == true)
                        .Include(x => x.CinemaRoom)
                        .Include(x=>x.Movie)
                        .OrderBy(x => x.CreatedDate).ToList();

                    return query;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Screening> GetScreeningByMovieAndCinema(int cinemaRoomID, int movieID)
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Screenings.Where(x => x.Enabled == true && x.CinemaRoomID == cinemaRoomID && x.MovieID == movieID)
                        .Include(x => x.CinemaRoom)
                        .Include(x => x.Movie)
                        .OrderBy(x => x.CreatedDate).ToList();

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
