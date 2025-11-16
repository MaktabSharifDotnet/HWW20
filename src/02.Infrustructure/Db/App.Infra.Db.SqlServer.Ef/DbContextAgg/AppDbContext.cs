using App.Domain.Core._Common.Entities;
using App.Domain.Core.CarModelAgg.Entities;
using App.Domain.Core.OperatorAgg.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Db.SqlServer.Ef.DbContextAgg
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<BaseAppointmentRequest> BaseAppointmentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


    }
}
