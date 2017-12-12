using AutoReservation.Common.DataTransferObjects;
using AutoReservation.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool CanLoad()
        {
            return ServiceExists;
        }
    }
}
