using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        public DateTime Geburtsdatum { get; set; }
        [Key]
        public int Id { get; set; }
        public string Nachname { get; set; }
        public byte RowVersion { get; set; }
        public string Vorname { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        [ForeignKey("Reservationen")]
        public ICollection<Reservation> Reservationen { get; set; }
    }
}
