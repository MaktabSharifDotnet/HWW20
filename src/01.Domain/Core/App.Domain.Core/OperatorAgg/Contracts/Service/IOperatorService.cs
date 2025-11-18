using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OperatorAgg.Contracts.Service
{
    public interface IOperatorService
    {
        public int Login(string username, string password);
    }
}
