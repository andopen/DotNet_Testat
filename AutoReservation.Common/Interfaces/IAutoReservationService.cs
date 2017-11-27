using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract(
           Namespace = "http://mste.hsr.testat/",
           SessionMode = SessionMode.Required)]
    public interface IAutoReservationService
    {
        List<AutoDto> List
        {
            [OperationContract]
            get;
            [OperationContract]
            set;
        }

        
    }
}
