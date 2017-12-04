using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationUpdateTest
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation reservation = Target.List[1];
            reservation.Bis = new DateTime(2070, 01, 10);

            Target.Update(reservation);

            Assert.AreEqual(reservation.Bis, Target.List.Find(a => reservation.ReservationsNr == a.ReservationsNr).Bis);
        }
    }
}
