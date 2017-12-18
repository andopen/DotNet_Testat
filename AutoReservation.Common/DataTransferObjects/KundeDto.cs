using System;
using System.Runtime.Serialization;
using System.Text;

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

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Lastname is not set.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Firstname is not set.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Birthdate is not set.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override int GetId()
        {
            return Id;
        }

    }
}
