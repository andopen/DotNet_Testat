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
            return null;
        }

        public Auto Insert(Auto auto)
        {
            return null;
        }

        public Auto Update(Auto auto)
        {
            return null;
        }

        public void Delete(Auto auto)
        {

        }
    }
}
