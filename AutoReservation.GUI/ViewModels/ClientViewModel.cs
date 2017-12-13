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
    public class ClientViewModel : BaseViewModel<KundeDto>
    {
        private RelayCommand loadCommand;

        public ICommand LoadCommand => loadCommand ?? (loadCommand = new RelayCommand(param => Load(), () => CanLoad()));

        protected override void Load()
        {
            items.Clear();
            Service.AllKunden.ToList().ForEach(items.Add);
            SelectedItem = items.FirstOrDefault();
        }

        private bool CanLoad() => ServiceExists;

        private RelayCommand newCommand;

        public ICommand NewCommand => newCommand ?? (newCommand = new RelayCommand(param => New(), () => CanNew()));

        protected void New()
        {
            items.Add(new KundeDto());
        }

        private bool CanNew() => ServiceExists;

        private RelayCommand saveCommand;

        public ICommand SaveCommand => saveCommand ?? (saveCommand = new RelayCommand(param => SaveData(), () => CanSaveData()));

        private void SaveData()
        {
            try
            {
                foreach (var client in items)
                {
                    if (client.Id == default(int))
                    {
                        Service.InsertKunde(client);
                        Load();
                    }
                    else
                    {
                        Service.UpdateKunde(client);
                    }
                }
                Load();
            }
            catch (FaultException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSaveData() => ServiceExists;

    }
}
