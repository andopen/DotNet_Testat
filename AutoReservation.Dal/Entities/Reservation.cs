using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        public int ReservationsNr { get; set; }
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
