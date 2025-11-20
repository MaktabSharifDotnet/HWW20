using App.Domain.Core.AppointmentRequestAgg.Contracts.Repo;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.AppointmentRequestAgg.Extensions;
using App.Domain.Core.CarModelAgg.Contracts.Repository;
using App.Domain.Core.CarModelAgg.Dtos;
using App.Domain.Core.CarModelAgg.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppointmentRequestAgg
{
    public class AppointmentRequestService(IAppointmentRequestRepo appointmentRequestRepo
        , ICarModelRepo carModelRepos) : IAppointmentRequestService
    {
        public int Create(RegisterInfoDto registerInfoDto)
        {
           int count= appointmentRequestRepo.GetCountByRequsetDate(registerInfoDto.RequestDateMiladi);

            CarModelDto? carModelDto=carModelRepos.GetById(registerInfoDto.CarModelId);
            if (carModelDto==null)
           {
               throw new Exception("مدل انتخاب شده نامعتبر است.");
           }

            bool isEvenDay=IsEvenDay(registerInfoDto.RequestDateMiladi);
            if (isEvenDay)
            {
                if (carModelDto.Company != CompanyEnum.IranKhodro)
                {
                    throw new Exception("در روز های زوج فقط ماشین های ایرانخودرو ثبت سفارش میشوند");
                }
                if (count>=15)
                {
                    throw new Exception("ظرفیت تکمیل است.");
                }
            }
            else 
            {
                if (carModelDto.Company != CompanyEnum.Saipa)
                {
                    throw new Exception("در روز های فرد فقط ماشین های سایپا ثبت سفارش میشوند");
                }
                if (count >= 10)
                {
                    throw new Exception("ظرفیت تکمیل است.");
                }
            }

            var status = RequestStatusEnum.Pending;
            var description = "";
            bool isCarOld=registerInfoDto.Year.IsCarOld();
            if (isCarOld) 
            {
               status=RequestStatusEnum.Failed_AgeCriteria;
               description = "درخواست رد شد به این دلیل که طول عمر خودرو بیش از 5 سال است. ";

            }

            bool isExistLicensePlate = appointmentRequestRepo.IsExistLicensePlate(registerInfoDto.LicensePlate);
            if (isExistLicensePlate) 
            {
                throw new Exception("این پلاک قبلا درخواست ثبت کرده است .");
            }


            AppointmentRequest appointmentRequest = new AppointmentRequest()
            {
                OwnerName = registerInfoDto.OwnerName,
                Mobile = registerInfoDto.Mobile,
                NationalCode = registerInfoDto.NationalCode,
                LicensePlate = registerInfoDto.LicensePlate,
                Address = registerInfoDto.Address,
                Year = registerInfoDto.Year,
                RequestDate = registerInfoDto.RequestDateMiladi,
                Status = status,
                CarModelId = registerInfoDto.CarModelId,
                Logs = new List<RequestLog>() 
                {
                    new RequestLog()
                    {
                       OldStatus = RequestStatusEnum.None,
                       NewStatus = status,
                       ChangedAt=DateTime.Now,
                       Description = description,
                    }
                }

            };

           return appointmentRequestRepo.Create(appointmentRequest);

        }

        public List<AppointmentRequestSummaryDto> GetAll()
        {
           return appointmentRequestRepo.GetAll();
        }

        public AppointmentRequestSummaryDto GetById(int id)
        {
          return  appointmentRequestRepo.GetById(id);
        }

        private bool IsEvenDay(DateTime requsetDate) 
        {
            return requsetDate.DayOfWeek == DayOfWeek.Saturday
                || requsetDate.DayOfWeek==DayOfWeek.Monday
                ||requsetDate.DayOfWeek==DayOfWeek.Wednesday;
        }
    }
}
