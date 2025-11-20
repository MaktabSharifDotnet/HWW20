using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Contracts.Service
{
    public interface IAppointmentRequestService
    {
        public int Create(RegisterInfoDto registerInfoDto);
        public List<AppointmentRequestSummaryDto> GetAll();

        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto);
        public AppointmentRequestSummaryDto? GetById(int id);

        public List<AppointmentRequestSummaryDto> GetFiltered(AppointmentFilterDto appointmentFilterDto);



    }
}
