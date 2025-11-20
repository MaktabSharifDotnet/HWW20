using App.Domain.Core._common.InMemory;
using App.Domain.Core.OperatorAgg.Contracts.Repository;
using App.Domain.Core.OperatorAgg.Contracts.Service;
using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.OperatorAgg
{
    public class OperatorService(IOperatorRepository operatorRepository) : IOperatorService
    {
        public Operator GetByUsername(string username)
        {
           return operatorRepository.GetByUsername(username);
        }

        public int Login(string username, string password)
        {
            Operator operatorDb=operatorRepository.GetByUsername(username);
            if (operatorDb==null || operatorDb.Password!=password)
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه است.");
            }
            LocalStorage.Operator = operatorDb;
            return operatorDb.Id;
        }
    }
}
