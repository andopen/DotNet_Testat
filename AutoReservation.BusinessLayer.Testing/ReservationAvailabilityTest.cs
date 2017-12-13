using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationAvailabilityTest
    {
        private ReservationManager target;
        private ReservationManager Target => target ?? (target = new ReservationManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void ScenarioOkay01Test()
        {
            Reservation reservation = new Reservation { ReservationsNr = 4, AutoId = 1, KundeId = 1, Von = new DateTime(2017, 10, 10), Bis = new DateTime(2018, 10, 10) };

            Assert.IsTrue(ReservationManager.AvailabilityCheck(reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis));
        }

        [TestMethod]
        public void ScenarioOkay02Test()
        {
            Reservation reservation = new Reservation { ReservationsNr = 4, AutoId = 1, KundeId = 1, Von = new DateTime(2020, 01, 20), Bis = new DateTime(2020, 01, 30)};

            Assert.IsTrue(ReservationManager.AvailabilityCheck(reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis));
        }
        
        [TestMethod]
        public void ScenarioNotOkay01Test()
        {
            Reservation reservation = new Reservation { ReservationsNr = 4, AutoId = 1, KundeId = 1, Von = new DateTime(2020, 01, 15), Bis = new DateTime(2020, 01, 30) };

            Assert.IsFalse(ReservationManager.AvailabilityCheck(reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis));
        }

        [TestMethod]
        public void ScenarioNotOkay02Test()
        {
            Reservation reservation = new Reservation { ReservationsNr = 4, AutoId = 1, KundeId = 1, Von = new DateTime(2020, 01, 05), Bis = new DateTime(2020, 01, 15) };

            Assert.IsFalse(ReservationManager.AvailabilityCheck(reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis));
        }

        [TestMethod]
        public void ScenarioNotOkay03Test()
        {
            Reservation reservation = new Reservation { ReservationsNr = 4, AutoId = 1, KundeId = 1, Von = new DateTime(2020, 01, 10), Bis = new DateTime(2020, 01, 20) };

            Assert.IsFalse(ReservationManager.AvailabilityCheck(reservation.ReservationsNr, reservation.AutoId, reservation.Von, reservation.Bis));
        }
    }
}
