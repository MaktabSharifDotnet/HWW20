using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class AppointmentFilterDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public CompanyEnum? CompanyEnum { get; set; }
    }
}
