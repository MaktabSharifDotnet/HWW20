using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Contracts.Repository
{
    public interface IAppointmentRequestRepository
    {
        public int Create(AppointmentRequest appointmentRequest);
        public int GetCountByDate(DateTime requestDate);
        public List<AppointmentRequestSummaryDto> GetAll();
        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto);

    }
}
