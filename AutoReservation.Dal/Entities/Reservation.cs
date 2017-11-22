using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        [Key]
        int AutoId { get; set; }
        DateTime Bis { get; set; }
        [ForeignKey("KundenId")]
        int KundenId { get; set; }
        int ReservationsNr { get; set; }
        byte RowVersion { get; set; }
        DateTime Von { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
    
}
