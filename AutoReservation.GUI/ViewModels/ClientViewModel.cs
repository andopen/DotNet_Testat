using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.GUI.ViewModels
{
    public class ClientViewModel : BaseViewModel<KundeDto>
    {
        protected override void Load()
        {
            items.Clear();
            Service.AllKunden.ToList().ForEach(items.Add);
            SelectedItem = items.FirstOrDefault();
        }
    }
}
