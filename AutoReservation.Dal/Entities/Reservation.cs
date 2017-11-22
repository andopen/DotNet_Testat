using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        [Key]
        public int AutoId { get; set; }
        public DateTime Bis { get; set; }
        [ForeignKey("KundenId")]
        public int KundeId { get; set; }
        public int ReservationsNr { get; set; }
        public byte RowVersion { get; set; }
        public DateTime Von { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
    
}
