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

        public int ChangeStatus(ChangeStatusInfoDto changeStatusInfoDto)
        {
            
            var request = _context.AppointmentRequests.FirstOrDefault(r => r.Id == changeStatusInfoDto.RequestId);

            if (request == null)
            {
                throw new Exception("درخواست یافت نشد.");
            }
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
    }
}
