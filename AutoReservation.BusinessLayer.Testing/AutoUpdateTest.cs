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
            Auto auto = Target.List[1];
            auto.Tagestarif = 10;

            Target.Update(auto);

            Assert.AreEqual(auto.Tagestarif, Target.List.Find(a => auto.Id == a.Id).Tagestarif);
        }
    }
}
