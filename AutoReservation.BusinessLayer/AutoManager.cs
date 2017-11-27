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
        : ManagerBase<Auto>
    {
        public override List<Auto> List
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Autos.ToList();
                }
            }
        }

        public override Auto GetById(int id)
        {
            return null;
        }

        public override Auto Insert(Auto auto)
        {
            return null;
        }

        public override Auto Update(Auto auto)
        {
            return null;
        }

        public override void Delete(Auto auto)
        {

        }
    }
}
 