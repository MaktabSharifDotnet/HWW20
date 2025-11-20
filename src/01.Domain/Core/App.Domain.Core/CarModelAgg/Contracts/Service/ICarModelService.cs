using App.Domain.Core.CarModelAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarModelAgg.Contracts.Service
{
    public interface ICarModelService
    {
        public List<CarModelDto> GetAll();
        public CarModelDto? GetById(int carModelId);
    }
}
