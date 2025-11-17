using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarModelAgg.Dtos
{
    public class CarModelDto
    {
        public string Name { get; set; }
        public CompanyEnum Company { get; set; }
    }
}
