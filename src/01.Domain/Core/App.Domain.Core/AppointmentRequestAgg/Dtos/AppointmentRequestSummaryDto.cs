using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Dtos;
using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class AppointmentRequestSummaryDto
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string Address { get; set; }

        public int Year { get; set; }
        public DateTime RequestDate { get; set; }
  
        public string ModelName { get; set; }
        public CompanyEnum Company { get; set; }

        public RequestStatusEnum Status { get; set; }
        public int? OperatorId { get; set; }
    }
}
