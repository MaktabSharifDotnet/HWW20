using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._common.InMemory
{
    public static class LocalStorage
    {
        public static Operator? Operator { get; set; }
    }
}
