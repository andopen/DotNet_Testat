using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        DateTime Geburtsdatum { get; set; }
        [Key]
        int Id { get; set; }
        string Nachname { get; set; }
        byte RowVersion { get; set; }
        string Vorname { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        [ForeignKey("Reservationen")]
        ICollection<Reservation> Reservationen { get; set; }
    }
}
