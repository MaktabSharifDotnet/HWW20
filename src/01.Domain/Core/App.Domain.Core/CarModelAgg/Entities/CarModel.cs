
using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarModelAgg.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyEnum Company { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<AppointmentRequest> AppointmentRequests { get; set; }

    }
}
