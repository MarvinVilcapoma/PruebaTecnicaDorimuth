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
    public class CinemaService : ICinemaInterface
    {
        private readonly ClientDBContext _context;

        public CinemaService(ClientDBContext context)
        {
            _context = context;
        }

        public List<Cinema> GetCinemas()
        {
            try
            {
                using (var context = new ClientDBContext())
                {
                    var query = context.Cinemas.Where(x => x.Enabled == true)
                        .Include(x => x.District)
                        .Include(x => x.CinemaRooms)
                        .OrderBy(x => x.CinemaName).ToList();
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
