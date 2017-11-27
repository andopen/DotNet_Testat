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
        : ManagerBase<Kunde>
    {
        public override List<Kunde> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Kunden.ToList();
                }
            }
        }

        public override Kunde GetById(int id)
        {
            return null;
        }

        public override Kunde Insert(Kunde kunde)
        {
            return null;
        }

        public override Kunde Update(Kunde kunde)
        {
            return null;
        }

        public override void Delete(Kunde kunde)
        {

        }
    }
}