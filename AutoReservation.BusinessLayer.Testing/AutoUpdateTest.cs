using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class AutoUpdateTests
    {
        private AutoManager target;
        private AutoManager Target => target ?? (target = new AutoManager());


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto auto = new StandardAuto()
            {
                Marke = "Tesla",
                Tagestarif = 235
            };

            Auto autoInserted = Target.Insert(auto);
            Assert.AreNotEqual(0, autoInserted.Id);

            autoInserted.Marke = "Noname";
            autoInserted.Tagestarif = 365;

            Auto autoUpdated = Target.Update(autoInserted);

            Assert.AreEqual(autoInserted.GetType(), autoUpdated.GetType());
            Assert.AreEqual(autoInserted.Id, autoUpdated.Id);
            Assert.AreEqual(autoInserted.Marke, autoUpdated.Marke);
            Assert.AreEqual(autoInserted.Tagestarif, autoUpdated.Tagestarif);
        }
    }
}
