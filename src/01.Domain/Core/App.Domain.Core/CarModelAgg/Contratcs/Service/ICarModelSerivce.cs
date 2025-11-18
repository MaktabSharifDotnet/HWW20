using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarModelAgg.Contratcs.Service
{
    public interface ICarModelSerivce
    {
        public CarModelDto? GetById(int carModelId);
        public List<CarModelDto> GetAll();
    }
}
