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
        : ManagerBase<Reservation>
    {
        public override List<Reservation> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Reservationen.ToList();
                }
            }
        }

        public override Reservation GetById(int reservationsNr)
        {
            return null;
        }

        public override Reservation Insert(Reservation reservation)
        {
            return null;
        }

        public override Reservation Update(Reservation reservation)
        {
            return null;
        }

        public override void Delete(Reservation reservation)
        {

        }

    }
}