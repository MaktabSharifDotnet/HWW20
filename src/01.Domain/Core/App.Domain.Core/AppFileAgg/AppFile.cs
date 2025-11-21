using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppFileAgg
{
    public class AppFile
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int AppointmentRequestId { get; set; }
        public AppointmentRequest AppointmentRequest { get; set; }
    }
}
