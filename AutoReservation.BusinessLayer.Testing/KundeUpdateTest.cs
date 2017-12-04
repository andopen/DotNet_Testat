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
            Kunde client = Target.List[1];
            client.Nachname = "Tot";

            Target.Update(client);

            Assert.AreEqual(client.Nachname, Target.List.Find(a => client.Id == a.Id).Nachname);
        }
    }
}
