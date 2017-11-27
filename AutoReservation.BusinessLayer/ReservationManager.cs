using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal.Entities;

namespace AutoReservation.BusinessLayer
{
    public class ReservationManager
        : ManagerBase
    {
        public List<Reservation> AllReservationen
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Reservationen.ToList();
                }
            }
        }

        public Reservation GetReservationByReservationNr(int reservationNr)
        {
            return null;
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            return null;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            return null;
        }

        public void DeleteReservation(Reservation reservation)
        {

        }

    }
}