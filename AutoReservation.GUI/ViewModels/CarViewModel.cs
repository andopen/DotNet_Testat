using AutoReservation.Common.DataTransferObjects;
using AutoReservation.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutoReservation.GUI.ViewModels
{
    public class CarViewModel : BaseViewModel<AutoDto>
    {
        private RelayCommand loadCommand;

        public ICommand LoadCommand => loadCommand ?? (loadCommand = new RelayCommand(param => Load(), () => CanLoad()));

        protected override void Load()
        {
            items.Clear();
            Service.AllAutos.ToList().ForEach(items.Add);
            SelectedItem = items.FirstOrDefault();
        }

        private bool CanLoad() => ServiceExists;

        private RelayCommand newCommand;

        public ICommand NewCommand => newCommand ?? (newCommand = new RelayCommand(param => New(), () => CanNew()));

        protected void New()
        {
            items.Add(new AutoDto() { AutoKlasse = AutoKlasse.Standard, Tagestarif=0, Basistarif=0, Marke="noname"});
        }

        private bool CanNew() => ServiceExists;

        private RelayCommand saveCommand;

        public ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(param => SaveData(), () => CanSaveData()));

        private void SaveData()
        {
            try
            {
                foreach (var car in items)
                {
                    if (car.Id == default(int))
                    {
                        Service.InsertAuto(car);
                    }
                    else
                    {
                        Service.UpdateAuto(car);
                    }
                }
                Load();
            }
            catch (FaultException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSaveData() => ServiceExists && Validate(Items);

        private RelayCommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(param => Delete(), () => CanDelete()));
            }
        }

        private void Delete()
        {
            Service.DeleteAuto(SelectedItem);
            Load();
        }

        private bool CanDelete() => 
            ServiceExists &&
            SelectedItem != null &&
            SelectedItem.Id != default(int);
        

    }

}

