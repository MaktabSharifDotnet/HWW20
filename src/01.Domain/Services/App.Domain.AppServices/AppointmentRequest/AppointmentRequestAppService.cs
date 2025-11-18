using App.Domain.Core._common.InMemory;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.AppointmentRequest
{
    public class AppointmentRequestAppService(IAppointmentRequestService appointmentRequestService) : IAppointmentRequestAppService
    {
      

        public int Create(RegisterInfoDto registerInfoDto)  
        {
           return appointmentRequestService.Create(registerInfoDto);   
        }

        public List<AppointmentRequestSummaryDto> GetAll()
        {
            return appointmentRequestService.GetAll();
        }

        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto)
        {
            

            return appointmentRequestService.ChangeStatus(changeStatusInfoDto);
        }
    }
}
