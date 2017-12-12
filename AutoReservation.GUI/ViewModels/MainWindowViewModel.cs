using AutoReservation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
            ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            Service = channelFactory.CreateChannel();

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
