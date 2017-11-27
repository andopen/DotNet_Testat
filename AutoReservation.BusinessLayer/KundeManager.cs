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
        public List<Kunde> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Kunden.ToList();
                }
            }
        }

        public Kunde GetById(int id)
        {
            return null;
        }

        public Kunde Insert(Kunde kunde)
        {
            return null;
        }

        public Kunde Update(Kunde kunde)
        {
            return null;
        }

        public void Delete(Kunde kunde)
        {

        }
    }
}