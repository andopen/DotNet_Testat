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
        public List<Reservation> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Reservationen.ToList();
                }
            }
        }

        public Reservation GetById(int reservationsNr)
        {
            return null;
        }

        public Reservation Insert(Reservation reservation)
        {
            return null;
        }

        public Reservation Update(Reservation reservation)
        {
            return null;
        }

        public void Delete(Reservation reservation)
        {

        }

    }
}