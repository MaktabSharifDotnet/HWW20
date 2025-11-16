using App.Domain.Core.AppointmentRequestAgg.Entities;
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

    }
}
