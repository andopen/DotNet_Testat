using System;
using System.Runtime.Serialization;

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
    }
}
