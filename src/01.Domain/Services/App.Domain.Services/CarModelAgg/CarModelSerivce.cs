using App.Domain.Core.CarModelAgg.Contratcs.Repository;
using App.Domain.Core.CarModelAgg.Contratcs.Service;
using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.CarModelAgg
{
    public class CarModelSerivce(ICarModelRepository carModelRepository) : ICarModelSerivce
    {
        public List<CarModelDto> GetAll()
        {
          return carModelRepository.GetAll();
        }

        public CarModelDto? GetById(int carModelId)
        {
           var carModelDto= carModelRepository.GetById(carModelId);
            if (carModelDto==null)
            {
                throw new Exception("مدل خودرو نامعتبر است");
            }
            return carModelDto;
        }
        
    }
}
