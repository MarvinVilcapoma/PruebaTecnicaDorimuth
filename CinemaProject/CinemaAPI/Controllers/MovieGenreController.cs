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
    public class MovieGenreController : ControllerBase
    {
        private readonly IMovieGenreInterface _movieGenreInterface;

        private readonly IMapper _mapper;

        public MovieGenreController(IMovieGenreInterface movieGenreInterface, IMapper mapper)
        {
            _movieGenreInterface = movieGenreInterface;
            _mapper = mapper;

        }

        [Route("GetMovieGenres")]
        [HttpGet]
        public ActionResult<List<MovieGenre>> GetMovieGenres()
        {
            var moviesGenre = _movieGenreInterface.GetMovieGenres();

            if (moviesGenre != null && moviesGenre.Any())
            {
                return Ok(moviesGenre);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
