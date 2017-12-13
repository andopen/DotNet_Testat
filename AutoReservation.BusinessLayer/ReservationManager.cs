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
            using (AutoReservationContext context = new AutoReservationContext())
            {
                if (!DateRangeCheck(reservation))
                {
                    throw new InvalidDateRangeException("Invalid Date");
                }
                else if (!AvailabilityCheck(context, reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis))
                {
                    throw new AutoUnavailableException("Reservation Collision");
                }
                context.Entry(reservation).State = EntityState.Added;
                context.Entry(reservation).Reference(r => r.Auto).Load();
                context.Entry(reservation).Reference(r => r.Kunde).Load();
                context.SaveChanges();
                return reservation;
            }
        }

        public Reservation Update(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                if (!DateRangeCheck(reservation))
                {
                    throw new InvalidDateRangeException("Invalid Date");
                }
                else if (!AvailabilityCheck(context, reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis)) 
                {
                    throw new AutoUnavailableException("Reservation Collision");
                }
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
                try
                {
                    context.Entry(reservation).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateOptimisticConcurrencyExceptionOnDelete<Reservation>(context, reservation);
                }
            }
        }

        public static bool DateRangeCheck(Reservation reservation)
        {
            if ((reservation.Bis - reservation.Von).Days >= 1)
            {
                return true;
            }
            return false;
        }

        private static bool AvailabilityCheck(AutoReservationContext context, int reservationsNr, int autoId, DateTime von, DateTime bis)
        {
            return !context.Reservationen
            .Any(r =>
                r.AutoId == autoId &&
                r.ReservationsNr != reservationsNr &&
                !(r.Bis <= von ||
                r.Von >= bis));
        }

        public static bool AvailabilityCheck(int reservationsNr, int autoId, DateTime von, DateTime bis)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                return AvailabilityCheck(context, reservationsNr, autoId, von, bis);
            }
        }

        private static bool AvailabilityCheck(AutoReservationContext context, int autoId, DateTime von, DateTime bis)
        {
            return !context.Reservationen
            .Any(r =>
                r.AutoId == autoId &&
                !(r.Bis <= von ||
                r.Von >= bis));
        }

        public static bool AvailabilityCheck(int autoId, DateTime von, DateTime bis)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                return AvailabilityCheck(context, autoId, von, bis);
            }
        }

    }
}