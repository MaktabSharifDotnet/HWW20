using App.Domain.Core.OperatorAgg.Contracts.AppService;
using App.Domain.Core.OperatorAgg.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.OperatorAgg
{
    public class OperatorAppService(IOperatorService  operatorService) : IOperatorAppService
    {
        public int Login(string username, string password)
        {
           return operatorService.Login(username, password);
        }
    }
}
