using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using AutoReservation.GUI.Commands;

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
        #region Load Command
        protected RelayCommand loadCommand;
        public virtual ICommand LoadCommand => loadCommand ?? (loadCommand = new RelayCommand(param => Load(), () => CanLoad()));
        protected virtual bool CanLoad() => ServiceExists;
        protected abstract void Load();
        #endregion

        #region New Command
        protected RelayCommand newCommand;
        public virtual ICommand NewCommand => newCommand ?? (newCommand = new RelayCommand(param => New(), () => CanNew()));
        protected virtual bool CanNew() => ServiceExists;
        protected abstract void New();
        #endregion

        #region Save Command
        protected RelayCommand saveCommand;
        public virtual ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(param => SaveData(), () => CanSaveData()));
        protected virtual bool CanSaveData() => ServiceExists && Validate(Items);
        protected abstract void SaveData();
        #endregion

        #region Delete Command
        private RelayCommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(param => Delete(), () => CanDelete()));
        protected abstract bool CanDelete();
        protected abstract void Delete();
        #endregion

        #region Validate and Errors
        protected bool Validate(IEnumerable<T> items)
        {
            var errorText = new StringBuilder();
            foreach (IValidatable item in items)
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
        #endregion
    }
}
