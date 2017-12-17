using System;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.GUI.ViewModels;
using AutoReservation.Service.Wcf;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.GUI.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
            Service = new AutoReservationService();
        }

        public IAutoReservationService Service { get; set; }

        [TestMethod]
        public void CarsLoadTest()
        {
            CarViewModel vm = new CarViewModel();
            vm.Init(Service);

            ICommand targetCommand = vm.LoadCommand;

            Assert.IsTrue(targetCommand.CanExecute(null));

            targetCommand.Execute(null);

            Assert.AreEqual(3, vm.Items.Count);
        }

        [TestMethod]
        public void ClientsLoadTest()
        {
            ClientViewModel vm = new ClientViewModel();
            vm.Init(Service);

            ICommand targetCommand = vm.LoadCommand;

            Assert.IsTrue(targetCommand.CanExecute(null));

            targetCommand.Execute(null);

            Assert.AreEqual(4, vm.Items.Count);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            ReservationViewModel vm = new ReservationViewModel();
            vm.Init(Service);

            ICommand targetCommand = vm.LoadCommand;

            Assert.IsTrue(targetCommand.CanExecute(null));

            targetCommand.Execute(null);

            Assert.AreEqual(3, vm.Items.Count);
        }
    }
}
