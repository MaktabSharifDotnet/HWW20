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

            builder.HasData(
              new CarModel { Id = 1, Name = "پراید 131", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.Saipa, IsDeleted = false },
              new CarModel { Id = 2, Name = "تیبا 2", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.Saipa, IsDeleted = false },
              new CarModel { Id = 3, Name = "شاهین", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.Saipa, IsDeleted = false },
              new CarModel { Id = 4, Name = "پژو 206", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.IranKhodro, IsDeleted = false },
              new CarModel { Id = 5, Name = "پژو پارس", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.IranKhodro, IsDeleted = false },
              new CarModel { Id = 6, Name = "سمند LX", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.IranKhodro, IsDeleted = false },
              new CarModel { Id = 7, Name = "دنا پلاس", Company = App.Domain.Core.CarModelAgg.Enums.CompanyEnum.IranKhodro, IsDeleted = false }
          );

        }
    }
}