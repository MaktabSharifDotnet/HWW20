
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
                .HasMaxLength(11);
              

           
            builder.Property(ar => ar.Status)
                .IsRequired()
                .HasConversion<string>() 
                .HasMaxLength(50);

          
            builder.HasOne(ar => ar.CarModel)
                .WithMany(c=>c.AppointmentRequests)
                .HasForeignKey(ar => ar.CarModelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Logs)
              .WithOne(x => x.AppointmentRequest)
             .HasForeignKey(x => x.RequestId);

            builder.HasOne(ar => ar.Operator)
                .WithMany(o => o.AppointmentRequests) 
                .HasForeignKey(ar => ar.OperatorId)
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Images)               
               .WithOne(x => x.AppointmentRequest)  
               .HasForeignKey(x => x.AppointmentRequestId) 
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(ar => !ar.IsDeleted);
        }
    }
}