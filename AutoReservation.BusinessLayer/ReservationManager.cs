using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer.Exceptions;

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
                    return context.Reservationen
                        .Include(r => r.Auto)
                        .Include(r => r.Kunde)
                        .ToList();
                }
            }
        }

        public Reservation GetById(int reservationsNr)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                Reservation reservation = context.Reservationen
                    .Include(r => r.Auto)
                    .Include(r => r.Kunde)
                    .SingleOrDefault(r => r.ReservationsNr == reservationsNr);
                return reservation;
            }
        }

        public Reservation Insert(Reservation reservation)
        {
            if (!DateRangeCheck(reservation))
            {
                throw new InvalidDateRangeException("TODO");
            }
            else if (!AvailabilityCheck(reservation))
            {
                throw new AutoUnavailableException("TODO");
            }
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(reservation).State = EntityState.Added;
                context.Entry(reservation).Reference(r => r.Auto).Load();
                context.Entry(reservation).Reference(r => r.Kunde).Load();
                context.SaveChanges();
                return reservation;
            }
        }

        public Reservation Update(Reservation reservation)
        {
            if (!DateRangeCheck(reservation))
            {
                throw new InvalidDateRangeException("TODO");
            }
            else if (!AvailabilityCheck(reservation))
            {
                throw new AutoUnavailableException("TODO");
            }
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Entry(reservation).State = EntityState.Modified;
                    context.Entry(reservation).Reference(r => r.Auto).Load();
                    context.Entry(reservation).Reference(r => r.Kunde).Load();
                    context.SaveChanges();

                    return reservation;
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateOptimisticConcurrencyException<Reservation>(context, reservation);
                }
            }
        }

        public void Delete(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(reservation).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static bool DateRangeCheck(Reservation reservation)
        {
            if ((reservation.Bis - reservation.Von).TotalDays >= 24)
            {
                return true;
            }
            return false;
        }

        public Boolean AvailabilityCheck(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                return !context.Reservationen
                .Any(r =>
                    r.AutoId == reservation.AutoId &&
                    r.ReservationsNr != reservation.ReservationsNr &&
                    (r.Bis <= reservation.Von ||
                    r.Von >= reservation.Bis));
            }

        }

    }
}