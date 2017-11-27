﻿using System;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto
    {
        public AutoKlasse AutoKlasse { get; set; }
        public int Basistarif { get; set; }
        public int Id { get; set; }
        public string Marke { get; set; }
        public byte RowVersion { get; set; }
        public int Tagestarif { get; set; }
        //public override string ToString()
        //    => $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}; {RowVersion}";
    }
}
