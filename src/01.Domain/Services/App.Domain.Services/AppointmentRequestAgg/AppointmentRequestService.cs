using App.Domain.Core.AppointmentRequestAgg.Contracts.Repo;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppointmentRequestAgg
{
    public class AppointmentRequestService(IAppointmentRequestRepo appointmentRequestRepo) : IAppointmentRequestService
    {
        public List<AppointmentRequestSummaryDto> GetAll()
        {
           return appointmentRequestRepo.GetAll();
        }
    }
}
