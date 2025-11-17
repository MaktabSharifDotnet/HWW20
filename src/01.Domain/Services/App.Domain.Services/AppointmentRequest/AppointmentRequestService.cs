using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Contratcs.Repository;
using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppointmentRequest
{
    public class AppointmentRequestService (IAppointmentRequestRepository appointmentRequestRepository 
        , ICarModelRepository carModelRepository ) : IAppointmentRequestService
    {
        public int Create(RegisterInfoDto registerInfoDto)
        {
           var carModelDto= carModelRepository.GetById(registerInfoDto.CarModelId);
            if (carModelDto==null)
            {
                throw new Exception("ماشینی با این مدل موجود نیست");
            }

            var currentYear = DateTime.Now.Year;
            var carAge = DateTime.Now.Year - registerInfoDto.Year;
            RequestStatusEnum status = RequestStatusEnum.Pending;

            if (carAge>5)
            {
                status = RequestStatusEnum.Failed_AgeCriteria;
            }


            if (registerInfoDto.RequestDate.DayOfWeek == DayOfWeek.Friday) 
            {
                throw new Exception("امکان ثبت در خواست در روز جمعه نیست .");
            }

            bool result=IsEvenDay(registerInfoDto.RequestDate.DayOfWeek);

            if (result&&status==RequestStatusEnum.Pending)
            {
                if (carModelDto.Company== CompanyEnum.Saipa)
                {
                    status = RequestStatusEnum.Rejected;
                }
            }
            else if(!result&& status == RequestStatusEnum.Pending)
            {
                if (carModelDto.Company == CompanyEnum.IranKhodro)
                {
                    status = RequestStatusEnum.Rejected;
                }
            }

            int count= appointmentRequestRepository.GetCountByDate(registerInfoDto.RequestDate);
            if (status == RequestStatusEnum.Pending) 
            {
                if (count >= 10 && !result || count >= 15 && result)
                {
                    status = RequestStatusEnum.Failed_DailyLimit;
                }
            }
            return appointmentRequestRepository.Create(registerInfoDto , status);
        }
        private bool IsEvenDay(DayOfWeek day)
        {
          
            return day == DayOfWeek.Saturday ||
                   day == DayOfWeek.Monday ||
                   day == DayOfWeek.Wednesday;
        }
    }
}
