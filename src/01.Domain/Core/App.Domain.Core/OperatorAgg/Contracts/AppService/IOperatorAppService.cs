using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OperatorAgg.Contracts.AppService
{
    public interface IOperatorAppService
    {
        public int Login(string username, string password);
        public Operator GetByUsername(string username);
    }
}
