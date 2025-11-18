using App.Domain.Core.OperatorAgg.Contracts.Repository;
using App.Domain.Core.OperatorAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.OperatorAgg
{
    public class OperatorRepository(AppDbContext _context) : IOperatorRepository
    {
        public Operator? GetByUsername(string username)
        {
            return _context.Operators.FirstOrDefault(x => x.Username == username);
        }
    }
}
