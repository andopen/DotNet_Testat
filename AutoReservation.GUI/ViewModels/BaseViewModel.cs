using AutoReservation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.GUI.ViewModels
{
    public abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        protected readonly ObservableCollection<T> items = new ObservableCollection<T>();
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<T> Items
        {
            get { return items; }
        }

        private T selectedItem;
        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (!Equals(selectedItem, value))
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(selectedItem));
                }
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected IAutoReservationService Service { get; private set; }

        public bool ServiceExists => Service != null;


        public void Init(IAutoReservationService service)
        {
            Service = service;
            Load();
        }

        protected abstract void Load();
    }
}
