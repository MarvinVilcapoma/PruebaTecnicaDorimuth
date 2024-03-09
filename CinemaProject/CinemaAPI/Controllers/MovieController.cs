using AutoMapper;
using Common.Base;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieInterface _movieInterface;

        private readonly IMapper _mapper;


        public MovieController(IMovieInterface movieInterface, IMapper mapper)
        {
            _movieInterface = movieInterface;
            _mapper = mapper;

        }

        [Route("GetMovies")]
        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            var movies = _movieInterface.GetMovies();

            if (movies != null && movies.Any())
            {
                return Ok(movies);
            }
            else
            {
                return NotFound(); 
            }
        }

        [Route("GetMovieById/{ID}")]
        [HttpGet]
        public ActionResult<List<Movie>> GetMovieById(int ID)
        {
            var movies = _movieInterface.GetMovieById(ID);

            if (movies != null)
            {
                return Ok(movies);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("SearchMovie")]
        [HttpPost]
        public ActionResult<List<Movie>> SearchMovie([FromBody] SearchMovieRequestV1 requestV1)
        {
            var movies = _movieInterface.SearchMovie(requestV1);

            if (movies != null)
            {
                return Ok(movies);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
