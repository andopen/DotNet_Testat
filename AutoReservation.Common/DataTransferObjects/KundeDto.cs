using System;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase<KundeDto>
    {
        private int id;
        [DataMember]
        public int Id
        {
            get
            { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string nachname;
        [DataMember]
        public string Nachname
        {
            get { return nachname; }
            set
            {
                if (nachname != value)
                {
                    nachname = value;
                    OnPropertyChanged(nameof(Nachname));
                }
            }
        }

        private string vorname;
        [DataMember]
        public string Vorname
        {
            get { return vorname; }
            set
            {
                if (vorname != value)
                {
                    vorname = value;
                    OnPropertyChanged(nameof(Vorname));
                }
            }
        }

        private DateTime geburtsdatum;
        [DataMember]
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set
            {
                if (geburtsdatum != value)
                {
                    geburtsdatum = value;
                    OnPropertyChanged(nameof(Geburtsdatum));
                }
            }
        }

        [DataMember]
        public byte[] RowVersion { get; set; }

        public override string ToString()
            => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}; {RowVersion}";
    }
}
