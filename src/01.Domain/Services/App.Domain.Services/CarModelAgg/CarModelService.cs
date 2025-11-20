using App.Domain.Core.CarModelAgg.Contracts.Repository;
using App.Domain.Core.CarModelAgg.Contracts.Service;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.CarModelAgg
{
    public class CarModelService(ICarModelRepo carModelRepo) : ICarModelService
    {
        public List<CarModelDto> GetAll()
        {
            return carModelRepo.GetAll();
        }

        public CarModelDto? GetById(int carModelId)
        {
            return carModelRepo.GetById(carModelId);
        }
    }
}
