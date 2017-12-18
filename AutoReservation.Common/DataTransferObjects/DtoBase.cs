using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public abstract class DtoBase<T> : INotifyPropertyChanged, IValidatable, IGetId
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Validate();

        public abstract int GetId();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
