using App.Domain.Core.CarModelAgg.Dtos;
using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarModelAgg.Contratcs.Repository
{
    public interface ICarModelRepository
    {
        public CarModelDto GetById(int carModelId);
        public List<CarModelDto> GetAll();
    }
}
