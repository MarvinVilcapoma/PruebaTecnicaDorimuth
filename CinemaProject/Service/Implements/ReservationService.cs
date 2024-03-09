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
    public class ReservationService : IReservationInterface
    {
        private readonly ClientDBContext _context;

        public ReservationService(ClientDBContext context)
        {
            _context = context;
        }
        public Reservation Reservation(ReservationRequestV1 reservationRequestV1)
        {
            try
            {
                using (var context = new ClientDBContext())
                {

                    var cinemaRoom = context.CinemaRooms.Where(x => x.Enabled == true && x.CinemaRoomID == reservationRequestV1.CinemaRoomID)
                        .Include(x => x.Cinema).FirstOrDefault();

                    var movie = context.Movies.Where(x => x.Enabled == true && x.MovieID == reservationRequestV1.MovieID)
                        .Include(x => x.MovieGenre).FirstOrDefault();

                    var newReservation = new Reservation
                    {
                        Names = reservationRequestV1.Names,
                        LastNames = reservationRequestV1.LastNames,
                        BirthDate = reservationRequestV1.BirthDate,
                        Gender = reservationRequestV1.Gender,
                        DNI = reservationRequestV1.DNI,
                        Email = reservationRequestV1.Email,
                        CinemaRoomID = reservationRequestV1.CinemaRoomID,
                        CinemaRoom = cinemaRoom,
                        MovieID = reservationRequestV1.MovieID,
                        Movie = movie,
                        Enabled = true,
                        CreatedDate = DateTime.Now
                    };

                    context.Reservations.Add(newReservation);

                    context.SaveChanges();

                    return newReservation;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
