using AutoReservation.Common.DataTransferObjects;
using AutoReservation.GUI.Commands;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

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

        protected override void New()
        {
            items.Add(new AutoDto() { AutoKlasse = AutoKlasse.Standard, Tagestarif=0, Basistarif=0, Marke="noname"});
        }

        protected override void SaveData()
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

        protected override void Delete()
        {
            Service.DeleteAuto(SelectedItem);
            Load();
        }
    }

}

