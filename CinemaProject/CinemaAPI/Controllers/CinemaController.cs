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
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaInterface _cinemaInterface;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaInterface cinemaInterface, IMapper mapper)
        {
            _cinemaInterface = cinemaInterface;
            _mapper = mapper;
        }

        [Route("GetCinemas")]
        [HttpGet]
        public ActionResult<List<Cinema>> GetCinemas()
        {
            var cinemas = _cinemaInterface.GetCinemas();

            if (cinemas != null && cinemas.Any())
            {
                return Ok(cinemas);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
