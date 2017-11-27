using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Common.DataTransferObjects.Faults
{
    [DataContract]
    public class OptimisticConcurrencyFault <T>
    {
        public OptimisticConcurrencyFault(T dto)
        {
            Dto = dto;
        }

        [DataMember]
        public T Dto { get; set; }
    }
}
