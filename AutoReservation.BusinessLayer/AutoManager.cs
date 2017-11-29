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
        public List<Auto> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Autos.ToList();
                }
            }
        }

        public Auto GetById(int id)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                Auto auto = context.Autos.SingleOrDefault(a => a.Id == id);
                return auto;
            }
        }

        public Auto Insert(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(auto).State = EntityState.Added;
                context.SaveChanges();
                return auto;
            }
        }

        public Auto Update(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Entry(auto).State = EntityState.Modified;
                    context.SaveChanges();

                    return auto;
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw CreateOptimisticConcurrencyException<Auto>(context, auto);
                }
            }
        }

        public void Delete(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Entry(auto).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
