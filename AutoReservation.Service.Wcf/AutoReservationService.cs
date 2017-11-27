using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        public List<AutoDto> AllAutos => throw new NotImplementedException();

        public List<KundeDto> AllKunden => throw new NotImplementedException();

        public List<ReservationDto> AllReservationen => throw new NotImplementedException();

        private static void WriteActualMethod() 
            => Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");

        public void DeleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public AutoDto GetAutoById(int id)
        {
            throw new NotImplementedException();
        }

        public KundeDto GetKundeById(int id)
        {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservationByNr(int reservationsNr)
        {
            throw new NotImplementedException();
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public AutoDto UpdateAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public KundeDto UpdateKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public ReservationDto UpdateReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }
    }
}