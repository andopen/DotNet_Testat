using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class KundeUpdateTest
    {
        private KundeManager target;
        private KundeManager Target => target ?? (target = new KundeManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde kunde = new Kunde
            {
                Nachname = "Harry",
                Vorname = "Potter",
                Geburtsdatum = new DateTime(1976, 12, 12)
            };

            Kunde kundeInserted = Target.Insert(kunde);
            Assert.AreNotEqual(0, kundeInserted.Id);

            kundeInserted.Nachname = "Morgan";
            kundeInserted.Vorname = "Freeman";

            Kunde kundeUpdated = Target.Update(kundeInserted);

            Assert.AreEqual(kundeInserted.Id, kundeUpdated.Id);
            Assert.AreEqual(kundeInserted.Nachname, kundeUpdated.Nachname);
            Assert.AreEqual(kundeInserted.Vorname, kundeUpdated.Vorname);
            Assert.AreEqual(kundeInserted.Geburtsdatum, kundeUpdated.Geburtsdatum);
        }
    }
}
