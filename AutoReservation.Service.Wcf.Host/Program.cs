using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Host
{
    public class Program
    {

        private static List<Kunde> Kunden =>
            new List<Kunde>
            {
                        new Kunde {Id = 1, Nachname = "Nass", Vorname = "Anna", Geburtsdatum = new DateTime(1981, 05, 05)},
                        new Kunde {Id = 2, Nachname = "Beil", Vorname = "Timo", Geburtsdatum = new DateTime(1980, 09, 09)},
                        new Kunde {Id = 3, Nachname = "Pfahl", Vorname = "Martha", Geburtsdatum = new DateTime(1990, 07, 03)},
                        new Kunde {Id = 4, Nachname = "Zufall", Vorname = "Rainer", Geburtsdatum = new DateTime(1954, 11, 11)},
            };

        private static List<Auto> Autos =>
            new List<Auto>
            {
                new StandardAuto {Id = 1, Marke = "Fiat Punto", Tagestarif = 50},
                new MittelklasseAuto {Id = 2, Marke = "VW Golf", Tagestarif = 120},
                new LuxusklasseAuto {Id = 3, Marke = "Audi S6", Tagestarif = 180, Basistarif = 50},
            };

        private static List<Reservation> Reservationen =>
            new List<Reservation>
            {
                new Reservation { ReservationsNr = 1, AutoId = 1, KundeId = 1, Von = new DateTime(2020, 01, 10), Bis = new DateTime(2020, 01, 20)},
                new Reservation { ReservationsNr = 2, AutoId = 2, KundeId = 2, Von = new DateTime(2020, 01, 10), Bis = new DateTime(2020, 01, 20)},
                new Reservation { ReservationsNr = 3, AutoId = 3, KundeId = 3, Von = new DateTime(2020, 01, 10), Bis = new DateTime(2020, 01, 20)},
            };

        static void Main(string[] args)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Database.ExecuteSqlCommand($"DELETE FROM Auto");
                context.Database.ExecuteSqlCommand($"DELETE FROM Kunde");
                context.Database.ExecuteSqlCommand($"DELETE FROM Reservations");
                context.Autos.AddRange(Autos);
                context.Kunden.AddRange(Kunden);
                context.Reservationen.AddRange(Reservationen);
                context.SaveChanges();
            }

            Console.WriteLine("AutoReservationService starting.");

            // Instantiate new ServiceHost 
            ServiceHost host = new ServiceHost(typeof(AutoReservationService));

            // Open ServiceHost
            host.Open();

            Console.WriteLine("AutoReservationService started.");
            Console.WriteLine();
            Console.WriteLine("Press Return to stop the Service.");

            Console.ReadLine();

            // Stop ServiceHost
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
            }
        }
    }
}
