using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public byte[] RowVersion { get; set; }
    }

    public partial class LuxusklasseAuto : Auto
    {
        public int Basistarif { get; set; }
    }

    public partial class MittelklasseAuto : Auto { }

    public partial class StandardAuto : Auto { }

}
