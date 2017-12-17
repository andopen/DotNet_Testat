using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class ReservationDto : DtoBase<ReservationDto>
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

        private DateTime von;
        [DataMember]
        public DateTime Von
        {
            get { return von; }
            set
            {
                if (von != value)
                {
                    von = value;
                    OnPropertyChanged(nameof(Von));
                }
            }
        }

        private DateTime bis;
        [DataMember]
        public DateTime Bis
        {
            get { return bis; }
            set
            {
                if (bis != value)
                {
                    bis = value;
                    OnPropertyChanged(nameof(Bis));
                }
            }
        }

        private AutoDto auto;
        [DataMember]
        public AutoDto Auto
        {
            get { return auto; }
            set
            {
                if (auto != value)
                {
                    auto = value;
                    OnPropertyChanged(nameof(Auto));
                }
            }
        }

        private KundeDto kunde;
        [DataMember]
        public KundeDto Kunde
        {
            get { return kunde; }
            set
            {
                if (kunde != value)
                {
                    kunde = value;
                    OnPropertyChanged(nameof(Kunde));
                }
            }
        }

        [DataMember]
        public byte[] RowVersion { get; set; }

        public override string ToString()
            => $"{Id}; {Von}; {Bis}; {Auto}; {Kunde}";

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- From-Date is not set.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Until-Date is not set.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- From-Date is greater than Until-Date.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Car is not set.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Client is not set.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }
    }
}
