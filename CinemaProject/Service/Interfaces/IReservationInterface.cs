using Domain;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IReservationInterface
    {
        public Reservation Reservation(ReservationRequestV1 reservationRequestV1);

    }
}
