using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Enums
{
    public enum RequestStatusEnum
    {
        None = 0,
        Pending = 1,  
        Approved = 2, 
        Rejected = 3,
        Failed_AgeCriteria = 4,
        Failed_DailyLimit = 5

    }
}
