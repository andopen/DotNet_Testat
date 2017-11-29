using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace AutoReservation.Dal.Entities
{
    [Table("Auto")]
    public abstract class Auto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Marke { get; set; }
        [Required]
        public int Tagestarif { get; set; }
        public virtual ICollection<Reservation> Reservationen{get; set;}

        [Timestamp]
        public byte[] RowVersion { get; set; }
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
