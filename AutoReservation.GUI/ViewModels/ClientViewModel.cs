using AutoReservation.Common.DataTransferObjects;
using AutoReservation.GUI.Commands;
using System;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

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

        protected override void New()
        {
            items.Add(new KundeDto(){ Geburtsdatum = (DateTime)default(SqlDateTime), Vorname = "todo", Nachname = "verification"});
        }

        protected override void SaveData()
        {
            try
            {
                foreach (var client in items)
                {
                    if (client.Id == default(int))
                    {
                        Service.InsertKunde(client);
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

        protected override bool CanDelete() =>
            ServiceExists &&
            SelectedItem != null &&
            SelectedItem.Id != default(int);

        protected override void Delete()
        {
            Service.DeleteKunde(SelectedItem);
            Load();
        }
    }
}
