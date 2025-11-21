using App.Domain.Core.AppFileAgg;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.OperatorAgg.Entities;


    public class AppointmentRequest
    {
        public int Id { get; set; }

        public string OwnerName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string Address { get; set; }

        public int Year { get; set; }
        public DateTime RequestDate { get; set; }

        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        public int? OperatorId { get; set; }
        public Operator? Operator { get; set; }

        public bool IsDeleted { get; set; }

        public List<AppFile> Images { get; set; } = [];
        
       
        public List<RequestLog> Logs { get; set; } = [];
    }


