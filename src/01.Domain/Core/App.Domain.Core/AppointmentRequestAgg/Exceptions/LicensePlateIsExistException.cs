using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppointmentRequestAgg.Exceptions
{
    public class LicensePlateIsExistException : Exception
    {

        public LicensePlateIsExistException(string message) : base(message)

        {
        }
    }
}
