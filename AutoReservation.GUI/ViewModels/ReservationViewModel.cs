﻿using AutoReservation.Common.DataTransferObjects;
using AutoReservation.GUI.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AutoReservation.GUI.ViewModels
{
    public class ReservationViewModel : BaseViewModel<ReservationDto>
    {
        public override ReservationDto SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    SelectedCarId = value?.Auto?.Id ?? 0;
                    SelectedClientId = value?.Kunde?.Id ?? 0;

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private int selectedCarId;
        public int SelectedCarId
        {
            get { return selectedCarId; }
            set
            {
                if (selectedCarId != value)
                {
                    selectedCarId = value;
                    if (SelectedItem != null)
                    {
                        SelectedItem.Auto = Cars.SingleOrDefault(a => a.Id == value);
                    }

                    OnPropertyChanged(nameof(SelectedCarId));
                }
            }
        }

        private int selectedClientId;
        public int SelectedClientId
        {
            get { return selectedClientId; }
            set
            {
                if (selectedClientId != value)
                {
                    selectedClientId = value;
                    if (SelectedItem != null)
                    {
                        SelectedItem.Kunde = Clients.SingleOrDefault(k => k.Id == value);
                    }

                    OnPropertyChanged(nameof(SelectedClientId));
                }
            }
        }

        private readonly ObservableCollection<AutoDto> cars = new ObservableCollection<AutoDto>();
        public ObservableCollection<AutoDto> Cars
        {
            get { return cars; }
        }

        private readonly ObservableCollection<KundeDto> clients = new ObservableCollection<KundeDto>();
        public ObservableCollection<KundeDto> Clients
        {
            get { return clients; }
        }

        protected override void Load()
        {
            items.Clear();
            clients.Clear();
            cars.Clear();
            Service.AllAutos.ToList().ForEach(cars.Add);
            Service.AllKunden.ToList().ForEach(clients.Add);
            Service.AllReservationen.ToList().ForEach(items.Add);
            SelectedItem = items.FirstOrDefault();
        }

        protected override void New()
        {
            items.Add(new ReservationDto() { Von = DateTime.Today, Bis = DateTime.Today.AddDays(1) });
        }


        protected override void SaveData()
        {
            try
            {
                foreach (var reservation in items)
                {
                    if (reservation.Id == default(int))
                    {
                        Service.InsertReservation(reservation);
                    }
                    else
                    {
                        Service.UpdateReservation(reservation);
                    }
                }
                Load();
            }
            catch (FaultException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void Delete()
        {
            Service.DeleteReservation(SelectedItem);
            Load();
        }


        #region Live Command
        private RelayCommand liveCommand;

        private DispatcherTimer timer;
        private DispatcherTimer Timer { get => timer ?? (timer = new DispatcherTimer()); }

        public ICommand LiveCommand => liveCommand ?? (liveCommand = new RelayCommand(param => Live(), () => CanLive()));

        private void Live()
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
            }
            else
            {
                Timer.Interval = TimeSpan.FromSeconds(1);
                Timer.Tick += (sender, args) =>
                {
                    // Do something...
                    if (LoadCommand.CanExecute(null))
                    {
                        LoadCommand.Execute(null);
                    }
                };
                Timer.Start();
            }
            OnPropertyChanged("IsLive");
        }
        private bool CanLive() => ServiceExists;

        public bool IsLive => Timer.IsEnabled;

        #endregion
        #region Validation
        public bool IsReservationActive(object r)
        {
            ReservationDto reservation = r as ReservationDto;
            return reservation != null && reservation.Von <= DateTime.Today && reservation.Bis >= DateTime.Today;
        }
        #endregion

    }
}
