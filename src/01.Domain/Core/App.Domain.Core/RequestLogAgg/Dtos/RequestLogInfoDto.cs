using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.RequestLogAgg.Dtos
{
    public class RequestLogInfoDto
    {
        public int RequestId { get; set; }
        public RequestStatusEnum OldStatus { get; set; }
        public RequestStatusEnum NewStatus { get; set; }

        
        public int OperatorId { get; set; }
        public string Description { get; set; }

    }
}
