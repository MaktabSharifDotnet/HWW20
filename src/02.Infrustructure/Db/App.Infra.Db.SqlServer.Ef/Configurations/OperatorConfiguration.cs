using App.Domain.Core.OperatorAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Operators");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Username).IsRequired().HasMaxLength(300);
            builder.Property(o => o.Password).IsRequired().HasMaxLength(1000);
            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}