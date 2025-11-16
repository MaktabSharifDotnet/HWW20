using App.Domain.Core.CarModelAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.ToTable("CarModels");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

            builder.Property(c => c.Company)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}