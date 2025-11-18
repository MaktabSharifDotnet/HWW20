using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Enums; 

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class AppointmentRequestSummaryDto
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string LicensePlate { get; set; }
        public string CarModelName { get; set; } 
        public CompanyEnum Company { get; set; } 

        public DateTime RequestDate { get; set; }
        public RequestStatusEnum Status { get; set; }
    }
}