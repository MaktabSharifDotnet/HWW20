using App.Domain.Core._Common.Entities;
using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.OperatorAgg.Entities;
using App.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.FailedRequestLogAgg.Entities
{
    public class FailedRequestLog : BaseAppointmentRequest
    {

        public int? OperatorId { get; set; }
        public Operator? Operator { get; set; }
        
    }
}
