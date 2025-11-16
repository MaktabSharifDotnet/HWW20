using App.Domain.Core.FailedRequestLogAgg.Entities;
using App.Infra.Db.SqlServer.Ef.Configurations.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    public class FailedRequestLogConfiguration : IEntityTypeConfiguration<FailedRequestLog>
    {
        public void Configure(EntityTypeBuilder<FailedRequestLog> builder)
        {
            builder.ToTable("FailedRequestLogs");
            builder.HasKey(f => f.Id);

         
            builder.Property(f => f.OwnerName).IsRequired().HasMaxLength(250);
            builder.Property(f => f.NationalCode).IsRequired().HasMaxLength(10).IsFixedLength(true);
            builder.Property(f => f.LicensePlate).IsRequired().HasMaxLength(20);
            builder.Property(f => f.Address).IsRequired().HasMaxLength(500);
            builder.Property(f => f.RequestDate).IsRequired();
            builder.Property(f => f.Mobile).IsRequired().HasMaxLength(11).HasConversion(new MobileNumberConverter());

            
            builder.HasOne(f => f.CarModel)
                .WithMany()
                .HasForeignKey(f => f.CarModelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Operator)
                .WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(f => !f.IsDeleted);
        }
    }
}