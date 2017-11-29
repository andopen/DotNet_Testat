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
            using (AutoReservationContext context = new AutoReservationContext())
            {
                Kunde kunde = context.Kunden.SingleOrDefault(k => k.Id == id);
                return kunde;
            }
        }

        public Kunde Insert(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(kunde).State = EntityState.Added;
                context.SaveChanges();
                return kunde;
            }
        }

        public Kunde Update(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Entry(kunde).State = EntityState.Modified;
                    context.SaveChanges();

                    return kunde;
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateOptimisticConcurrencyException<Kunde>(context, kunde);
                }
            }
        }

        public void Delete(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(kunde).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}