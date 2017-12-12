using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.GUI.ViewModels
{
    public class CarViewModel : BaseViewModel<AutoDto>
    {
        protected override void Load()
        {
            items.Clear();
            Service.AllAutos.ToList().ForEach(items.Add);
            SelectedItem = items.FirstOrDefault();
        }
    }
}
