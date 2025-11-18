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
                    Id = c.Id,
                   Name = c.Name,
                   Company = c.Company,
                }).FirstOrDefault();
        }
        public List<CarModelDto> GetAll() 
        {
            return _context.CarModels.Select(c=>new CarModelDto 
            {
               Id = c.Id,
               Company = c.Company,
               Name = c.Name,
            }).ToList();
        }
    }
}
