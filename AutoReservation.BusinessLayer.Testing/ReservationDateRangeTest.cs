using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class ReservationDateRangeTest
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
            Assert.IsTrue(ReservationManager.DateRangeCheck(Target.List[0]));
        }

        [TestMethod]
        public void ScenarioOkay02Test()
        {
            Reservation reservation = Target.List[1];
            reservation.Bis = new DateTime(2020, 01, 11);

            Assert.IsTrue(ReservationManager.DateRangeCheck(reservation));
        }

        [TestMethod]
        public void ScenarioNotOkay01Test()
        {
            Reservation reservation = Target.List[1];
            reservation.Bis = new DateTime(2020, 01, 10);

            Assert.IsFalse(ReservationManager.DateRangeCheck(reservation));
        }

        [TestMethod]
        public void ScenarioNotOkay02Test()
        {
            Reservation reservation = Target.List[1];
            reservation.Bis = reservation.Von;

            Assert.IsFalse(ReservationManager.DateRangeCheck(reservation));
        }

        [TestMethod]
        public void ScenarioNotOkay03Test()
        {
            Reservation reservation = Target.List[1];
            reservation.Bis = reservation.Von.AddHours(10);

            Assert.IsFalse(ReservationManager.DateRangeCheck(reservation));
        }
    }
}
