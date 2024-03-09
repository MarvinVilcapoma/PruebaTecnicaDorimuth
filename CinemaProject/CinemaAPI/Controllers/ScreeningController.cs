using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningInterface _screeningInterface;

        private readonly IMapper _mapper;

        public ScreeningController(IScreeningInterface screeningInterface, IMapper mapper)
        {
            _screeningInterface = screeningInterface;
            _mapper = mapper;

        }

        [Route("GetScreenings")]
        [HttpGet]
        public ActionResult<List<MovieGenre>> GetScreenings()
        {
            var screenings = _screeningInterface.GetScreenings();

            if (screenings != null && screenings.Any())
            {
                return Ok(screenings);
            }
            else
            {
                return NotFound();
            }
        }


        [Route("GetScreeningByMovieAndCinema/{cinemaRoomID}/{movieID}")]
        [HttpGet]
        public ActionResult<List<MovieGenre>> GetScreeningByMovieAndCinema(int cinemaRoomID, int movieID)
        {
            var screenings = _screeningInterface.GetScreeningByMovieAndCinema(cinemaRoomID, movieID);

            if (screenings != null && screenings.Any())
            {
                return Ok(screenings);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
