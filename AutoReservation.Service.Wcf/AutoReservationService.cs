using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;
using System.Data.Entity.Core;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer.Exceptions;
using AutoReservation.Common.DataTransferObjects.Faults;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoManager autoManager;
        private KundeManager kundeManager;
        private ReservationManager reservationManager;

        private AutoManager AutoManager
        {
            get
            {
                return autoManager ?? (autoManager = new AutoManager());         
            }
        }

        private KundeManager KundeManager
        {
            get
            {
                return kundeManager ?? (kundeManager = new KundeManager());
            }
        }
        private ReservationManager ReservationManager
        {
            get
            {
                return reservationManager ?? (reservationManager = new ReservationManager());
            }
        }

        public List<AutoDto> AllAutos
        {
            get
            {
                WriteActualMethod();
                return AutoManager.List.ConvertToDtos();
            }
        }
        public List<KundeDto> AllKunden
        {
            get
            {
                WriteActualMethod();
                return KundeManager.List.ConvertToDtos();
            }
        }

        public List<ReservationDto> AllReservationen
        {
            get
            {
                WriteActualMethod();
                return ReservationManager.List.ConvertToDtos();
            }
        }

        private static void WriteActualMethod()
            => Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");

        public void DeleteAuto(AutoDto auto)
        {
            try
            {
                WriteActualMethod();
                AutoManager.Delete(auto.ConvertToEntity());
            }
            catch (OptimisticConcurrencyException<Auto> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<AutoDto>>(new OptimisticConcurrencyFault<AutoDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }

        }

        public void DeleteKunde(KundeDto kunde)
        {
            try
            {
                WriteActualMethod();
                KundeManager.Delete(kunde.ConvertToEntity());
            }
            catch (OptimisticConcurrencyException<Kunde> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<KundeDto>>(new OptimisticConcurrencyFault<KundeDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            try
            {
                WriteActualMethod();
                ReservationManager.Delete(reservation.ConvertToEntity());
            }
            catch (OptimisticConcurrencyException<Reservation> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<ReservationDto>>(new OptimisticConcurrencyFault<ReservationDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }
        }

        public AutoDto GetAutoById(int id)
        {
            WriteActualMethod();
            return AutoManager.GetById(id).ConvertToDto();
        }

        public KundeDto GetKundeById(int id)
        {
            WriteActualMethod();
            return KundeManager.GetById(id).ConvertToDto();
        }

        public ReservationDto GetReservationByNr(int reservationsNr)
        {
            WriteActualMethod();
            return ReservationManager.GetById(reservationsNr).ConvertToDto();
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            return AutoManager.Insert(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            return KundeManager.Insert(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            try
            {
                return ReservationManager.Insert(reservation.ConvertToEntity()).ConvertToDto();
            }
            catch (InvalidDateRangeException ex)
            {
                throw new FaultException<InvalidDateRangeFault>(new InvalidDateRangeFault(), ex.Message);
            }
            catch (AutoUnavailableException ex)
            {
                throw new FaultException<AutoUnavailableFault>(new AutoUnavailableFault(), ex.Message);
            }
        }

        public AutoDto UpdateAuto(AutoDto auto)
        {
            WriteActualMethod();
            try
            {
                return AutoManager.Update(auto.ConvertToEntity()).ConvertToDto();
            }
            catch (OptimisticConcurrencyException<Auto> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<AutoDto>>(new OptimisticConcurrencyFault<AutoDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }
        }

        public KundeDto UpdateKunde(KundeDto kunde)
        {
            WriteActualMethod();
            try
            {
                return KundeManager.Update(kunde.ConvertToEntity()).ConvertToDto();
            }
            catch (OptimisticConcurrencyException<Kunde> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<KundeDto>>(new OptimisticConcurrencyFault<KundeDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }
        }

        public ReservationDto UpdateReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            try
            {
                return ReservationManager.Update(reservation.ConvertToEntity()).ConvertToDto();
            }
            catch (OptimisticConcurrencyException<Reservation> ex)
            {
                throw new FaultException<OptimisticConcurrencyFault<ReservationDto>>(new OptimisticConcurrencyFault<ReservationDto>(ex.MergedEntity.ConvertToDto()), ex.Message);
            }
            catch (InvalidDateRangeException ex)
            {
                throw new FaultException<InvalidDateRangeFault>(new InvalidDateRangeFault(), ex.Message);
            }
            catch (AutoUnavailableException ex)
            {
                throw new FaultException<AutoUnavailableFault>(new AutoUnavailableFault(), ex.Message);
            }
        }

        public bool IsAutoAvailable(int autoId, DateTime von, DateTime bis)
        {
            return ReservationManager.AvailabilityCheck(autoId, von, bis);
        }
    }
}