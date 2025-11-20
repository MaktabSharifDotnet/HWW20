using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Contracts.AppService
{
    public interface IAppointmentRequestAppService
    {
        public List<AppointmentRequestSummaryDto> GetAll();
        public int Create(RegisterInfoDto registerInfoDto);
    }
}
