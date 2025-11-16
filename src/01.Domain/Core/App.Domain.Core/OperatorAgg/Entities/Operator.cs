
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OperatorAgg.Entities
{
    public class Operator
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<AppointmentRequest> AppointmentRequests { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
