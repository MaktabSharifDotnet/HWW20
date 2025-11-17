using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.AppointmentRequestAgg
{
    public class AppointmentRequestRepository(AppDbContext _context) : IAppointmentRequestRepository
    {
        public int Create(RegisterInfoDto registerInfo , RequestStatusEnum status)
        {
            var appointmentRequest = new AppointmentRequest
            {
                OwnerName = registerInfo.OwnerName,
                Mobile = registerInfo.Mobile,
                NationalCode = registerInfo.NationalCode,
                LicensePlate = registerInfo.LicensePlate,
                Address = registerInfo.Address,
                Year = registerInfo.Year,
                RequestDate = registerInfo.RequestDate,
                CarModelId = registerInfo.CarModelId,
                Status = status,
                OperatorId = null,
                IsDeleted = false,
               
            };
      
            _context.AppointmentRequests.Add(appointmentRequest);
            _context.SaveChanges();
            return appointmentRequest.Id;
        }

        public int GetCountByDate(DateTime requestDate)
        {
            throw new NotImplementedException();
        }
    }
}
