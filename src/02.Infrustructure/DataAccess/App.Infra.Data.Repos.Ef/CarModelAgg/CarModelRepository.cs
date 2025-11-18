using App.Domain.Core.CarModelAgg.Contratcs.Repository;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CarModelAgg
{
    public class CarModelRepository(AppDbContext _context) : ICarModelRepository
    {
        public CarModelDto? GetById(int carModelId)
        {
           return _context.CarModels
                .Where(c => c.Id == carModelId)
                .Select(c => new CarModelDto
                {
                   Name = c.Name,
                   Company = c.Company,
                }).FirstOrDefault();
        }
    }
}
