using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class ChangeStatusInfoDto
    {
        public int RequestId { get; set; }
        public RequestStatusEnum NewStatusEnum { get; set; }

        public int OperatorId { get; set; }
    }
}
