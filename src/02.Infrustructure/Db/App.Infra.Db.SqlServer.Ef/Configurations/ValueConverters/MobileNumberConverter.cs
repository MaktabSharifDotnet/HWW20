using App.Domain.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Infra.Db.SqlServer.Ef.Configurations.ValueConverters
{
    public class MobileNumberConverter : ValueConverter<MobileNumber, string>
    {
        public MobileNumberConverter() : base(mn => mn.Value, mn => new MobileNumber(mn))
        {


        }
    }
}