using System;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal.Entities;

namespace AutoReservation.BusinessLayer
{
    public class KundeManager
        : ManagerBase
    {
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

        public Kunde GetKundeById(int id)
        {
            return null;
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            return null;
        }

        public Kunde UpdateKunde(Kunde kunde)
        {
            return null;
        }

        public void DeleteKunde(Kunde kunde)
        {

        }
    }
}