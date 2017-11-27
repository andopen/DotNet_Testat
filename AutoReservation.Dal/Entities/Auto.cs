using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace AutoReservation.Dal.Entities
{
    public abstract class Auto
    {
        [Key]
        public int Id { get; set; }
        public string Marke { get; set; }
        public byte RowVersion { get; set; }
        public int Tagestarif { get; set; }
        [ForeignKey("Reservationen")]
        public ICollection<Reservation> Reservationen{get; set;}

        [Timestamp]
        public byte[] Timestamp { get; set; }

    }
    public class StandardAuto : Auto
    {

    }

    public class LuxusklasseAuto : Auto
    {
        public int Basistarif { get; set; }
    }

    public class MittelklasseAuto : Auto
    {

    }
}
