using App.Domain.Core.OperatorAgg.Contracts.AppService;
using App.Domain.Core.OperatorAgg.Contracts.Service;
using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.OperatorAgg
{
    public class OperatorAppService(IOperatorService  operatorService) : IOperatorAppService
    {
        public Operator GetByUsername(string username)
        {
            return  operatorService.GetByUsername(username);
        }

        public int Login(string username, string password)
        {
           return operatorService.Login(username, password);
        }
    }
}
