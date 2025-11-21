using App.Domain.Core._common.InMemory;
using App.Domain.Core._common.Utils;
using App.Domain.Core.AppFileAgg;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.AppointmentRequestAgg.Exceptions;
using App.Domain.Core.CarModelAgg.Contratcs.Repository;
using App.Domain.Core.CarModelAgg.Enums;
using App.Domain.Core.RequestLogAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppointmentRequestAgg
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
         
            RequestStatusEnum status = RequestStatusEnum.Pending;
            string logDescription = "ثبت اولیه درخواست";
            bool checkCarAge=registerInfoDto.Year.IsCarModelTooOld();
            if (checkCarAge)
            {
                
                status = RequestStatusEnum.Failed_AgeCriteria;
                logDescription = "رد شده توسط سیستم: سن خودرو بیش از ۵ سال است.";

            }

            if (registerInfoDto.RequestDateMiladi.DayOfWeek == DayOfWeek.Friday) 
            {
                throw new Exception("امکان ثبت در خواست در روز جمعه نیست .");
            }

            bool result=IsEvenDay(registerInfoDto.RequestDateMiladi.DayOfWeek);

            if (result&&status==RequestStatusEnum.Pending)
            {
                if (carModelDto.Company== CompanyEnum.Saipa)
                {
                    status = RequestStatusEnum.Rejected;
                    logDescription = "رد شده توسط سیستم: عدم تطابق شرکت سازنده با روز فرد.";
                }
            }
            else if(!result&& status == RequestStatusEnum.Pending)
            {
                if (carModelDto.Company == CompanyEnum.IranKhodro)
                {
                    status = RequestStatusEnum.Rejected;
                    logDescription = "رد شده توسط سیستم: عدم تطابق شرکت سازنده با روز زوج.";
                }
            }

            bool check= appointmentRequestRepository.LicensePlateIsExist(registerInfoDto.LicensePlate);

            if (check)
            {
                throw new LicensePlateIsExistException("با این پلاک یک درخواست قبلا ثبت شده است .");
            }


            int count= appointmentRequestRepository.GetCountByDate(registerInfoDto.RequestDateMiladi);
 
            if (status == RequestStatusEnum.Pending) 
            {
                if (count >= 10 && !result || count >= 15 && result)
                {
                    status = RequestStatusEnum.Failed_DailyLimit;
                    logDescription = "رد شده توسط سیستم: تکمیل ظرفیت روزانه.";
                }
            }

            var appointmentRequest = new AppointmentRequest
            {
                OwnerName = registerInfoDto.OwnerName,
                Mobile = registerInfoDto.Mobile,
                NationalCode = registerInfoDto.NationalCode,
                LicensePlate = registerInfoDto.LicensePlate,
                Address = registerInfoDto.Address,
                Year = registerInfoDto.Year.ToGregorianYear(),
                RequestDate = registerInfoDto.RequestDateMiladi.Date,
                CarModelId = registerInfoDto.CarModelId,
                Status = status,
                OperatorId = null,
                IsDeleted = false,

                Logs = new List<RequestLog>
                {
                    new RequestLog
                    {
                        OldStatus = RequestStatusEnum.None,
                        NewStatus = status,
                        ChangedAt = DateTime.Now,
                        OperatorId = null,
                        Description = logDescription
                    }

                }

                ,
                Images = registerInfoDto.ImagePaths.Select(path => new AppFile
                {
                    Path = path

                }).ToList()

            };


            return appointmentRequestRepository.Create(appointmentRequest);
        }

        public List<AppointmentRequestSummaryDto> GetAll()
        {
           return appointmentRequestRepository.GetAll();
        }

        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto)
        {
            if (LocalStorage.Operator==null||changeStatusInfoDto.OperatorId!= LocalStorage.Operator.Id)
            {
                throw new Exception("اوپراتوری لاگین نکرده است .");
            }
           return appointmentRequestRepository.ChangeStatus(changeStatusInfoDto);
        }
        private bool IsEvenDay(DayOfWeek day)
        {
          
            return day == DayOfWeek.Saturday ||
                   day == DayOfWeek.Monday ||
                   day == DayOfWeek.Wednesday;
        }
    

        public AppointmentRequestSummaryDto? GetById(int id)
        {
            return appointmentRequestRepository.GetById(id);
        }

        public bool LicensePlateIsExist(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public List<AppointmentRequestSummaryDto> GetFiltered(AppointmentFilterDto appointmentFilterDto)
        {
           return appointmentRequestRepository.GetFiltered(appointmentFilterDto);
        }
    }
}
