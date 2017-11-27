using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal.Entities;

namespace AutoReservation.BusinessLayer
{
    public class AutoManager
        : ManagerBase
    {
        // Example
        public List<Auto> AllAutos
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Autos.ToList();
                }
            }
        }

        public List<Kunde> AllKunden
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Kunden.ToList();
                }
            }
        }

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


        public Auto GetAutoById(int id)
        {
            return null;
        }

        public Kunde GetKundeById(int id)
        {
            return null;
        }

        public Reservation GetReservationByReservationNr(int reservationNr)
        {
            return null;
        }

        public Auto InsertAuto(Auto auto)
        {
            return null;
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            return null;
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            return null;
        }

        public Auto UpdateAuto(Auto auto)
        {
            return null;
        }

        public Kunde UpdateKunde(Kunde kunde)
        {
            return null;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            return null;
        }

        public void DeleteAuto(Auto auto)
        {

        }

        public void DeleteKunde(Kunde kunde)
        {

        }

        public void DeleteReservation(Reservation reservation)
        {

        }

    }
}
 