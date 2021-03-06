﻿using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.GUI.ViewModels
{
    public class MainWindowViewModel
    {
        public CarViewModel CarViewModel { get; }
        public ClientViewModel ClientViewModel { get; }
        public ReservationViewModel ReservationViewModel { get; }
        protected IAutoReservationService Service { get; private set; }


        public MainWindowViewModel()
        {
            Service = new AutoReservationService();
            CarViewModel = new CarViewModel();
            ClientViewModel = new ClientViewModel();
            ReservationViewModel = new ReservationViewModel();
            Init();
        }

        public void Init()
        {
            CarViewModel.Init(Service);
            ClientViewModel.Init(Service);
            ReservationViewModel.Init(Service);
        }

    }
}
