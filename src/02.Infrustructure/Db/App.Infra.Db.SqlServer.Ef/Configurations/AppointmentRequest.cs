using App.Domain.Core.AppointmentRequestAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    public class AppointmentRequest : IEntityTypeConfiguration<AppointmentRequest>
    {
        public void Configure(EntityTypeBuilder<AppointmentRequest> builder)
        {
            throw new NotImplementedException();
        }
    }
}
