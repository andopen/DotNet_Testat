using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        #region Read all entities

        [TestMethod]
        public void GetAutosTest()
        {
            List<AutoDto> list = Target.AllAutos;
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GetKundenTest()
        {
            List<KundeDto> list = Target.AllKunden;
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            List<ReservationDto> list = Target.AllReservationen;
            Assert.IsTrue(list.Count > 0);
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            AutoDto auto = Target.GetAutoById(1);

            Assert.AreEqual(auto.Id, Target.GetAutoById(1).Id);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto client = Target.GetKundeById(1);

            Assert.AreEqual(client.Id, Target.GetKundeById(1).Id);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);

            Assert.AreEqual(reservation.ReservationsNr, Target.GetReservationByNr(1).ReservationsNr);
        }

        #endregion

        #region Get by not existing ID

        [TestMethod]
        public void GetAutoByIdWithIllegalIdTest()
        {
            AutoDto car = Target.GetAutoById(-4);

            Assert.IsNull(car);
        }

        [TestMethod]
        public void GetKundeByIdWithIllegalIdTest()
        {
            KundeDto client = Target.GetKundeById(-4);

            Assert.IsNull(client);
        }

        [TestMethod]
        public void GetReservationByNrWithIllegalIdTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(-4);

            Assert.IsNull(reservation);
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto car = new AutoDto { Marke = "Fiat Punto", Tagestarif = 50, AutoKlasse = AutoKlasse.Standard };

            AutoDto carInserted = Target.InsertAuto(car);

            Assert.IsNotNull(carInserted);
            Assert.AreNotEqual(0, carInserted.Id);
            Assert.AreEqual(car.Marke, carInserted.Marke);
            Assert.AreEqual(car.Tagestarif, carInserted.Tagestarif);
            Assert.AreEqual(car.AutoKlasse, carInserted.AutoKlasse);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto client = new KundeDto { Nachname = "Nass", Vorname = "Anna", Geburtsdatum = new DateTime(1981, 05, 05) };

            KundeDto clientInserted = Target.InsertKunde(client);

            Assert.IsNotNull(clientInserted);
            Assert.AreNotEqual(0, clientInserted);
            Assert.AreEqual(client.Nachname, clientInserted.Nachname);
            Assert.AreEqual(client.Vorname, clientInserted.Vorname);
            Assert.AreEqual(client.Geburtsdatum, clientInserted.Geburtsdatum);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            ReservationDto reservation = new ReservationDto { Auto = Target.GetAutoById(1), Kunde = Target.GetKundeById(1) , Von = new DateTime(2010, 01, 10), Bis = new DateTime(2010, 01, 20) };

            ReservationDto reservationInserted = Target.InsertReservation(reservation);

            Assert.IsNotNull(reservationInserted);
            Assert.AreNotEqual(0, reservationInserted.ReservationsNr);
            Assert.AreEqual(reservation.Auto.Id, reservationInserted.Auto.Id);
            Assert.AreEqual(reservation.Kunde.Id, reservationInserted.Kunde.Id);
            Assert.AreEqual(reservation.Bis, reservationInserted.Bis);
            Assert.AreEqual(reservation.Von, reservationInserted.Von);
        }

        #endregion

        #region Delete  

        [TestMethod]
        public void DeleteAutoTest()
        {
            Target.DeleteAuto(Target.GetAutoById(1));

            Assert.IsNull(Target.GetAutoById(1));
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            Target.DeleteKunde(Target.GetKundeById(1));

            Assert.IsNull(Target.GetKundeById(1));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Target.DeleteReservation(Target.GetReservationByNr(1));

            Assert.IsNull(Target.GetReservationByNr(1));
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto auto = new AutoDto()
            {
                Marke = "Tesla",
                Tagestarif = 235
            };

            AutoDto autoInserted = Target.InsertAuto(auto);
            Assert.AreNotEqual(0, autoInserted.Id);

            autoInserted.Marke = "Noname";
            autoInserted.Tagestarif = 365;

            AutoDto autoUpdated = Target.UpdateAuto(autoInserted);

            Assert.AreEqual(autoInserted.AutoKlasse, autoUpdated.AutoKlasse);
            Assert.AreEqual(autoInserted.Id, autoUpdated.Id);
            Assert.AreEqual(autoInserted.Marke, autoUpdated.Marke);
            Assert.AreEqual(autoInserted.Tagestarif, autoUpdated.Tagestarif);
            Assert.AreEqual(autoInserted.Basistarif, autoUpdated.Basistarif);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto kunde = new KundeDto
            {
                Nachname = "Harry",
                Vorname = "Potter",
                Geburtsdatum = new DateTime(1976, 12, 12)
            };

            KundeDto kundeInserted = Target.InsertKunde(kunde);
            Assert.AreNotEqual(0, kundeInserted.Id);

            kundeInserted.Nachname = "Morgan";
            kundeInserted.Vorname = "Freeman";

            KundeDto kundeUpdated = Target.UpdateKunde(kundeInserted);

            Assert.AreEqual(kundeInserted.Id, kundeUpdated.Id);
            Assert.AreEqual(kundeInserted.Nachname, kundeUpdated.Nachname);
            Assert.AreEqual(kundeInserted.Vorname, kundeUpdated.Vorname);
            Assert.AreEqual(kundeInserted.Geburtsdatum, kundeUpdated.Geburtsdatum);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto reservation = new ReservationDto()
            {
                Von = DateTime.Today.AddDays(30),
                Bis = DateTime.Today.AddDays(50),
                Auto = Target.GetAutoById(1),
                Kunde = Target.GetKundeById(1)
            };
            ReservationDto reservationInserted = Target.InsertReservation(reservation);
            Assert.AreNotEqual(0, reservationInserted.ReservationsNr);

            reservationInserted.Von = reservationInserted.Von.AddDays(20);
            reservationInserted.Bis = reservationInserted.Bis.AddDays(80);

            ReservationDto reservationUpdated = Target.UpdateReservation(reservationInserted);

            Assert.AreEqual(reservationInserted.ReservationsNr, reservationUpdated.ReservationsNr);
            Assert.AreEqual(reservationInserted.Von, reservationUpdated.Von);
            Assert.AreEqual(reservationInserted.Bis, reservationUpdated.Bis);
            Assert.AreEqual(reservationInserted.Auto.Id, reservationUpdated.Auto.Id);
            Assert.AreEqual(reservationInserted.Kunde.Id, reservationUpdated.Kunde.Id);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<AutoDto>>))]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            AutoDto car1 = Target.GetAutoById(1);
            AutoDto car2 = Target.GetAutoById(1);

            car1.Marke = "blah";
            car2.Marke = "blubb";

            Target.UpdateAuto(car1);
            Target.UpdateAuto(car2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<KundeDto>>))]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            KundeDto client1 = Target.GetKundeById(1);
            KundeDto client2 = Target.GetKundeById(1);

            client1.Nachname = "blah";
            client2.Nachname = "blubb";

            Target.UpdateKunde(client1);
            Target.UpdateKunde(client2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<ReservationDto>>))]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto reservation1 = Target.GetReservationByNr(1);
            ReservationDto reservation2 = Target.GetReservationByNr(1);

            reservation1.Bis = new DateTime(2030, 01, 10);
            reservation2.Bis = new DateTime(2040, 01, 10);

            Target.UpdateReservation(reservation1);
            Target.UpdateReservation(reservation2);
        }

        #endregion

        #region Delete with optimistic concurrency violation
        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<AutoDto>>))]
        public void DeleteAutoWithOptimisticConcurrencyTest()
        {
            AutoDto car1 = Target.GetAutoById(1);
            AutoDto car2 = Target.GetAutoById(1);

            Target.DeleteAuto(car1);
            Target.DeleteAuto(car2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<KundeDto>>))]
        public void DeleteKundeWithOptimisticConcurrencyTest()
        {
            KundeDto client1 = Target.GetKundeById(1);
            KundeDto client2 = Target.GetKundeById(1);

            Target.DeleteKunde(client1);
            Target.DeleteKunde(client2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OptimisticConcurrencyFault<ReservationDto>>))]
        public void DeleteReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto reservation1 = Target.GetReservationByNr(1);
            ReservationDto reservation2 = Target.GetReservationByNr(1);

            Target.DeleteReservation(reservation1);
            Target.DeleteReservation(reservation2);
        }

        #endregion

        #region Insert / update invalid time range

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidDateRangeFault>))]
        public void InsertReservationWithInvalidDateRangeTest()
        {
            ReservationDto reservation = new ReservationDto { Kunde = Target.GetKundeById(1), Auto = Target.GetAutoById(1), Von = new DateTime(2010, 10, 10), Bis = new DateTime(2001, 10, 10)};

            Target.InsertReservation(reservation);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoUnavailableFault>))]
        public void InsertReservationWithAutoNotAvailableTest()
        {
            ReservationDto reservation = new ReservationDto { Kunde = Target.GetKundeById(2), Auto = Target.GetAutoById(1), Von = new DateTime(2020, 01, 10), Bis = new DateTime(2020, 01, 20) };

            Target.InsertReservation(reservation);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<InvalidDateRangeFault>))]
        public void UpdateReservationWithInvalidDateRangeTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);

            reservation.Bis = reservation.Von.AddDays(-10);

            Target.UpdateReservation(reservation);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoUnavailableFault>))]
        public void UpdateReservationWithAutoNotAvailableTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);

            reservation.Auto = Target.GetAutoById(2);

            Target.UpdateReservation(reservation);
        }

        #endregion

        #region Check Availability

        [TestMethod]
        public void CheckAvailabilityIsTrueTest()
        {
            Assert.IsTrue(Target.IsAutoAvailable(1, new DateTime(2017, 10, 10), new DateTime(2018, 10, 10)));
        }

        [TestMethod]
        public void CheckAvailabilityIsFalseTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);
            Assert.IsFalse(Target.IsAutoAvailable(reservation.Auto.Id, reservation.Von, reservation.Bis));
        }

        #endregion
    }
}
