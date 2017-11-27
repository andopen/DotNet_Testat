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

        public Auto GetAutoById(int id)
        {
            return null;
        }

        public Auto InsertAuto(Auto auto)
        {
            return null;
        }

        public Auto UpdateAuto(Auto auto)
        {
            return null;
        }

        public void DeleteAuto(Auto auto)
        {

        }
    }
}
 