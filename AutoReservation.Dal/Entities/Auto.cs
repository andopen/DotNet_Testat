using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace AutoReservation.Dal.Entities
{
    public class Auto
    {
        [Key]
        int Id { get; set; }
        string Marke { get; set; }
        byte RowVersion { get; set; }
        int Tagestarif { get; set; }
        [ForeignKey("Reservationen")]
        ICollection<Reservation> Reservationen{get; set;}

        [Timestamp]
        public byte[] Timestamp { get; set; }

        //AutoKlassen fehlen noch
    }
}
