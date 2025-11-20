using App.Domain.Core.AppointmentRequestAgg.Contracts.Repo;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.AppointmentRequestAgg
{
    public class AppointmentRequestRepo(AppDbContext _context) : IAppointmentRequestRepo
    {
        public int Create(AppointmentRequest appointmentRequest)
        {
            _context.AppointmentRequests.Add(appointmentRequest);
            _context.SaveChanges();
            return appointmentRequest.Id;
        }

        public List<AppointmentRequestSummaryDto> GetAll()
        {
           return _context.AppointmentRequests.Select(a => new AppointmentRequestSummaryDto() 
            {
               Id = a.Id,
               OwnerName = a.OwnerName,
               Mobile=a.Mobile,
               NationalCode = a.NationalCode,
               LicensePlate = a.LicensePlate,
               Address = a.Address,
               Year = a.Year,
               RequestDate = a.RequestDate,
               ModelName=a.CarModel.Name,
               Company=a.CarModel.Company,
               Status=a.Status,
               OperatorId=a.OperatorId,
            }).ToList();
        }

        public AppointmentRequestSummaryDto GetById(int id)
        {
           return _context.AppointmentRequests.Where(a=>a.Id== id).Select(a => new AppointmentRequestSummaryDto() 
            {
               Status = a.Status,
            })
            .First();
        }

        public int GetCountByRequsetDate(DateTime RequsetDate)
        {
           return _context.AppointmentRequests.Where(a => a.RequestDate.Date == RequsetDate.Date).Count();
        }

        public bool IsExistLicensePlate(string licensePlate)
        {
          return  _context.AppointmentRequests.Any(a=>a.LicensePlate==licensePlate);
        }
    }
}
