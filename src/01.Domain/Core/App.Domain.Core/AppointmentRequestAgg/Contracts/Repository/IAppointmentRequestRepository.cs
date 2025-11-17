using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Contracts.Repository
{
    public interface IAppointmentRequestRepository
    {
        public int Create(RegisterInfoDto registerInfo);
        //public int CheckLimit(DateTime RequestDate);

    }
}
