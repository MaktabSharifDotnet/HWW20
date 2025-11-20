using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.AppointmentRequestAgg
{
    public class AppointmentRequestAppService(IAppointmentRequestService appointmentRequestService) : IAppointmentRequestAppService
    {
        public List<AppointmentRequestSummaryDto> GetAll()
        {
            return appointmentRequestService.GetAll();
        }
    }
}
