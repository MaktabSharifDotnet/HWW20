using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Dtos
{
    public class RegisterInfoDto
    {
        public string OwnerName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string Address { get; set; }

        public int Year { get; set; }
        public string RequestDate { get; set; }
        public DateTime RequestDateMiladi { get; set; }

        public int CarModelId { get; set; }
        
        public List<string> ImagePaths { get; set; } = [];
    }
}
