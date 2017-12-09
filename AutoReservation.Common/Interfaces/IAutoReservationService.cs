using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.DataTransferObjects.Faults;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract(
           Namespace = "http://mste.hsr.testat/",
           SessionMode = SessionMode.Required)]
    public interface IAutoReservationService
    {
        List<AutoDto> AllAutos
        {
            [OperationContract]
            get;
        }

        List<KundeDto> AllKunden
        {
            [OperationContract]
            get;
        }

        List<ReservationDto> AllReservationen
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        AutoDto GetAutoById(int id);

        [OperationContract]
        KundeDto GetKundeById(int id);

        [OperationContract]
        ReservationDto GetReservationByNr(int reservationsNr);

        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);

        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);

        [OperationContract]
        [FaultContract(typeof(AutoUnavailableFault))]
        [FaultContract(typeof(InvalidDateRangeFault))]
        ReservationDto InsertReservation(ReservationDto reservation);

        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrencyFault<AutoDto>))]
        AutoDto UpdateAuto(AutoDto auto);

        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrencyFault<KundeDto>))]
        KundeDto UpdateKunde(KundeDto kunde);

        [OperationContract]
        [FaultContract(typeof(OptimisticConcurrencyFault<ReservationDto>))]
        [FaultContract(typeof(AutoUnavailableFault))]
        [FaultContract(typeof(InvalidDateRangeFault))]
        ReservationDto UpdateReservation(ReservationDto reservation);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
