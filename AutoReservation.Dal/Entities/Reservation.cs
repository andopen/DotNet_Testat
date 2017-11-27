using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        [Key]
        public int AutoId { get; set; }
        [ForeignKey("AutoId")]
        public Auto Auto { get; set; }
        public DateTime Bis { get; set; }
        public int KundeId { get; set; }
        [ForeignKey("KundenId")]
        public Kunde Kunde { get; set; }
        public int ReservationsNr { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DateTime Von { get; set; }

    }
    
}
