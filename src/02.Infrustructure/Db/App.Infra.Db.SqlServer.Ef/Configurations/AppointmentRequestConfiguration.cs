using App.Domain.Core.AppointmentRequestAgg.Entities;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Infra.Db.SqlServer.Ef.Configurations.ValueConverters; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    
    public class AppointmentRequestConfiguration : IEntityTypeConfiguration<AppointmentRequest>
    {
        public void Configure(EntityTypeBuilder<AppointmentRequest> builder)
        {
         
            builder.ToTable("AppointmentRequests");

           
            builder.HasKey(ar => ar.Id);

            
            builder.Property(ar => ar.OwnerName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(ar => ar.NationalCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(true); 

            builder.Property(ar => ar.LicensePlate)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ar => ar.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(ar => ar.RequestDate)
                .IsRequired();

           
            builder.Property(ar => ar.Mobile)
                .IsRequired()
                .HasMaxLength(11) 
                .HasConversion(new MobileNumberConverter()); 

           
            builder.Property(ar => ar.Status)
                .IsRequired()
                .HasConversion<string>() 
                .HasMaxLength(50);

          
            builder.HasOne(ar => ar.CarModel)
                .WithMany()
                .HasForeignKey(ar => ar.CarModelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ar => ar.Operator)
                .WithMany() 
                .HasForeignKey(ar => ar.OperatorId)
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(ar => !ar.IsDeleted);
        }
    }
}