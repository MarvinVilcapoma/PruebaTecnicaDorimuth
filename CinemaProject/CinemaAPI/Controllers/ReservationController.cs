using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Service.Interfaces;
using System.Collections.Generic;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationInterface _reservationInterface;

        private readonly IMapper _mapper;

        public ReservationController(IReservationInterface reservationInterface, IMapper mapper)
        {
            _reservationInterface = reservationInterface;
            _mapper = mapper;

        }

        [Route("Reservation")]
        [HttpPost]
        public ActionResult<Reservation> Reservation([FromBody] ReservationRequestV1 reservationRequestV1)
        {
            var screenings = _reservationInterface.Reservation(reservationRequestV1);

            if (screenings != null)
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
