using App.Domain.Core.CarModelAgg.Contracts.Repository;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CarModelAgg
{
    public class CarModelRepo(AppDbContext _context) : ICarModelRepo
    {
        public List<CarModelDto> GetAll()
        {
           return _context.CarModels.Select(c => new CarModelDto
            {
                Id=c.Id,
                Name=c.Name,
                Company=c.Company,
            }).ToList();
        }

        public CarModelDto? GetById(int carModelId)
        {
           return _context.CarModels.Where(c=>c.Id==carModelId)
                .Select(c=>new CarModelDto 
                {
                  Id = c.Id,
                  Name=c.Name,
                  Company=c.Company,
                }).FirstOrDefault();
        }
    }
}
