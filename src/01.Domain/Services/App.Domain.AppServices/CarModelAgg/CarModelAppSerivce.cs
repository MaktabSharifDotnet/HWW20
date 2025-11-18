using App.Domain.Core.CarModelAgg.Contratcs.AppService;
using App.Domain.Core.CarModelAgg.Contratcs.Service;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CarModelAgg
{
    public class CarModelAppSerivce(ICarModelSerivce carModelSerivce) : ICarModelAppSerivce
    {
        public List<CarModelDto> GetAll()
        {
           return carModelSerivce.GetAll();
        }

        public CarModelDto? GetById(int carModelId)
        {
            return carModelSerivce.GetById(carModelId);
        }
    }
}
