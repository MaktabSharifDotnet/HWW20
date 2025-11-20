using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OperatorAgg.Contracts.Repository
{
    public interface IOperatorRepository
    {
        public Operator GetByUsername(string username);

        
       
    }
}
