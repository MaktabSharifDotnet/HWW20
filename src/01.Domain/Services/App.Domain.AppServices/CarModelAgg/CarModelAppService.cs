using App.Domain.Core.CarModelAgg.Contracts.AppService;
using App.Domain.Core.CarModelAgg.Contracts.Service;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CarModelAgg
{
    public class CarModelAppService(ICarModelService carModelService) : ICarModelAppService
    {
        public List<CarModelDto> GetAll()
        {
          return carModelService.GetAll();
        }

        public CarModelDto? GetById(int carModelId)
        {
           return carModelService.GetById(carModelId);
        }
    }
}
