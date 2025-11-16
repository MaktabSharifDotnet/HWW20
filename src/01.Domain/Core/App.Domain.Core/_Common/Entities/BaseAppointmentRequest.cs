using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Common.Entities
{
    public abstract class BaseAppointmentRequest
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public int Year { get; set; }
        public MobileNumber Mobile { get; set; }
        public string NationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string Address { get; set; }
        public DateTime RequestDate { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
