using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.RequestLogAgg.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.AppointmentRequestAgg
{
    public class AppointmentRequestRepository(AppDbContext _context) : IAppointmentRequestRepository
    {

        public int Create(AppointmentRequest appointmentRequest)
        {
    
            _context.AppointmentRequests.Add(appointmentRequest);
            _context.SaveChanges();
            return appointmentRequest.Id;
        }

        public List<AppointmentRequestSummaryDto> GetAll()
        {
           return _context.AppointmentRequests.Select(a => new AppointmentRequestSummaryDto
            {
                Id = a.Id,
                OwnerName = a.OwnerName,
                LicensePlate= a.LicensePlate,
                CarModelName = a.CarModel.Name,
                Company = a.CarModel.Company,
                RequestDate=a.RequestDate,
                Status = a.Status,
            }).ToList();
        }

        public int GetCountByDate(DateTime requestDate)
        { 
            return _context.AppointmentRequests.Where(a=>a.RequestDate.Date==requestDate.Date).Count();
        }
        public bool LicensePlateIsExist(string licensePlate) 
        {
          return _context.AppointmentRequests.Any(a=>a.LicensePlate==licensePlate);
        }
      

        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto)
        {
            
            var request = _context.AppointmentRequests.FirstOrDefault(r => r.Id == changeStatusInfoDto.RequestId);

            if (request == null)
            {
                throw new Exception("درخواست یافت نشد.");
            }
            request.OperatorId = changeStatusInfoDto.OperatorId;
            var log = new RequestLog
            {
                RequestId = request.Id,
                OldStatus = request.Status, 
                NewStatus = changeStatusInfoDto.NewStatusEnum,      
                ChangedAt = DateTime.Now,
                OperatorId = changeStatusInfoDto.OperatorId,
                Description = $"تغییر وضعیت توسط اپراتور به {changeStatusInfoDto.NewStatusEnum}"
            };

            
            request.Status = changeStatusInfoDto.NewStatusEnum;

           
            _context.RequestLogs.Add(log);

           return _context.SaveChanges();
        }

        public AppointmentRequestSummaryDto? GetById(int id)
        {
           return _context.AppointmentRequests.Where(a => a.Id == id)
                .Select(a => new AppointmentRequestSummaryDto 
                {
                    Id = a.Id,
                    Status = a.Status,
                    OwnerName = a.OwnerName,
                    LicensePlate = a.LicensePlate,
                    CarModelName = a.CarModel.Name,
                    Company=a.CarModel.Company,
                    RequestDate=a.RequestDate,

                }).FirstOrDefault();
        }

        public List<AppointmentRequestSummaryDto> GetFiltered(AppointmentFilterDto appointmentFilterDto)
        {
            var query = _context.AppointmentRequests.AsQueryable();

            if (appointmentFilterDto.FromDate.HasValue)
            {
                query = query.Where(a => a.RequestDate >= appointmentFilterDto.FromDate.Value);
            }
            if (appointmentFilterDto.ToDate.HasValue)
            {
                query = query.Where(a => a.RequestDate <= appointmentFilterDto.ToDate.Value);
            }
            if (appointmentFilterDto.CompanyEnum.HasValue)
            {
                query = query.Where(a => a.CarModel.Company == appointmentFilterDto.CompanyEnum.Value);
            }
            return query.Select(a => new AppointmentRequestSummaryDto
                  {
                      Id = a.Id,
                      OwnerName = a.OwnerName,
                      LicensePlate = a.LicensePlate,
                      CarModelName = a.CarModel.Name,
                      Company = a.CarModel.Company,
                      RequestDate=a.RequestDate,
                      Status = a.Status,

                  }).ToList();
        }
    }
}
