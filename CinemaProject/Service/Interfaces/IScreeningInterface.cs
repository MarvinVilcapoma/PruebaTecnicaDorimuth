using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IScreeningInterface
    {
        public List<Screening> GetScreenings();

        public List<Screening> GetScreeningByMovieAndCinema(int cinemaRoomID, int movieID);

    }
}
