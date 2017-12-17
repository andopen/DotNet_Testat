using System;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase<AutoDto>
    {
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string marke;
        [DataMember]
        public string Marke
        {
            get { return marke; }
            set
            {
                if (marke != value)
                {
                    marke = value;
                    OnPropertyChanged(nameof(Marke));
                }
            }
        }

        private int tagestarif;
        [DataMember]
        public int Tagestarif
        {
            get { return tagestarif; }
            set
            {
                if (tagestarif != value)
                {
                    tagestarif = value;
                    OnPropertyChanged(nameof(Tagestarif));
                }
            }
        }

        private int basistarif;
        [DataMember]
        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if (basistarif != value)
                {
                    basistarif = value;
                    OnPropertyChanged(nameof(Basistarif));
                }
            }
        }

        private AutoKlasse autoKlasse;
        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return autoKlasse; }
            set
            {
                if (autoKlasse != value)
                {
                    autoKlasse = value;
                    OnPropertyChanged(nameof(AutoKlasse));
                }
            }
        }

        [DataMember]
        public byte[] RowVersion { get; set; }

        public override string ToString()
            => $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}; {RowVersion}";
    }
}
