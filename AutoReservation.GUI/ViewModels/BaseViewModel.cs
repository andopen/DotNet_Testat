using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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

        protected T selectedItem;
        public virtual T SelectedItem
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

        protected bool Validate(IEnumerable<IValidatable> items)
        {
            var errorText = new StringBuilder();
            foreach (var item in items)
            {
                var error = item.Validate();
                if (!string.IsNullOrEmpty(error))
                {
                    errorText.AppendLine(item.ToString());
                    errorText.AppendLine(error);
                }
            }

            ErrorText = errorText.ToString();
            return string.IsNullOrEmpty(ErrorText);
        }

        private string errorText;
        public string ErrorText
        {
            get { return errorText; }
            set
            {
                if (errorText != value)
                {
                    errorText = value;
                    OnPropertyChanged(nameof(ErrorText));
                }
            }
        }

    }
}
