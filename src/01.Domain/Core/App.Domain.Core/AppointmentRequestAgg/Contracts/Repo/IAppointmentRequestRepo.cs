using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Contracts.Repo
{
    public interface IAppointmentRequestRepo
    {
        public List<AppointmentRequestSummaryDto> GetAll();
      
        public int GetCountByRequsetDate(DateTime RequsetDate);       
        public bool IsExistLicensePlate(string licensePlate);
        public int Create(AppointmentRequest appointmentRequest);
    }
}
