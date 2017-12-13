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
            Reservation reservation = new Reservation()
            {
                Von = DateTime.Today.AddDays(30),
                Bis = DateTime.Today.AddDays(50),
                AutoId = 1,
                KundeId = 1
            };
            Reservation reservationInserted = Target.Insert(reservation);
            Assert.AreNotEqual(0, reservationInserted.ReservationsNr);

            reservationInserted.Von = reservationInserted.Von.AddDays(20);
            reservationInserted.Bis = reservationInserted.Bis.AddDays(80);

            Reservation reservationUpdated = Target.Update(reservationInserted);

            Assert.AreEqual(reservationInserted.ReservationsNr, reservationUpdated.ReservationsNr);
            Assert.AreEqual(reservationInserted.Von, reservationUpdated.Von);
            Assert.AreEqual(reservationInserted.Bis, reservationUpdated.Bis);
            Assert.AreEqual(reservationInserted.AutoId, reservationUpdated.AutoId);
            Assert.AreEqual(reservationInserted.KundeId, reservationUpdated.KundeId);
        }
    }
}
