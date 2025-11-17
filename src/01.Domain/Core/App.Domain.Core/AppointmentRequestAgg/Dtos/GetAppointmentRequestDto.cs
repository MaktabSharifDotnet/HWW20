using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class GetAppointmentRequestDto
    {
        public string OwnerName { get; set; }
        public MobileNumber Mobile { get; set; }
        public string NationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string Address { get; set; }

        public int Year { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatusEnum Status { get; set; }
        public int CarModelId { get; set; }

    }
}
